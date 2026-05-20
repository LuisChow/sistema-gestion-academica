using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Formulario para la gestión y edición de notas académicas por materia y sección.
    /// Permite visualizar, agregar y editar notas de estudiantes en cursos específicos.
    /// </summary>
    public partial class NotasForm : Form
    {
        /// <summary>
        /// Cargador dinámico de bloques SQL definidos en archivos JSON.
        /// </summary>
        private readonly JsonLoader loader;
        /// <summary>
        /// Componente de base de datos para conexión y ejecución de consultas.
        /// </summary>
        private readonly DBComponent db;
        /// <summary>
        /// Conexión activa a la base de datos PostgreSQL.
        /// </summary>
        private NpgsqlConnection connection;
        /// <summary>
        /// Transacción actual para operaciones seguras.
        /// </summary>
        private NpgsqlTransaction? currentTransaction;
        /// <summary>
        /// Indica si se están actualizando las secciones para evitar eventos redundantes.
        /// </summary>
        private bool actualizandoSecciones = false;
        /// <summary>
        /// Indica si hay una transacción activa en curso.
        /// </summary>
        private bool transaccionActiva = false;

        /// <summary>
        /// Inicializa una nueva instancia del formulario de notas.
        /// </summary>
        /// <param name="dbComponent">Componente de base de datos conectado.</param>
        /// <param name="jsonLoader">Instancia del cargador de bloques SQL.</param>
        public NotasForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();

            db = dbComponent;
            loader = jsonLoader;

            connection = db.Connection ?? throw new InvalidOperationException("Conexión no inicializada.");

            Console.WriteLine(loader.BuildSql("notas_por_materia_y_seccion"));

            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dataGridView1.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Anadir",
                HeaderText = "Añadir",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            dataGridView1.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Edit",
                HeaderText = "Editar",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });

            InitComboBoxes();

            comboBoxMateria.SelectedIndexChanged += comboBoxMateria_SelectedIndexChanged;
            comboBoxSeccion.SelectedIndexChanged += ComboBoxes_SelectionChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            comboBoxMateria.SelectedIndex = 0;
        }

        /// <summary>
        /// Evento que se activa al hacer clic en el botón "Guardar".
        /// Confirma la transacción activa y cierra el formulario.
        /// </summary>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (transaccionActiva)
                {
                    currentTransaction?.Commit();
                    transaccionActiva = false;
                    currentTransaction = null;
                }

                MessageBox.Show("Cambios guardados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }

            connection.Close();
            this.Close();
        }

        /// <summary>
        /// Evento que se activa al hacer clic en el botón "Retroceso".
        /// Revierte la transacción activa y cierra el formulario.
        /// </summary>
        private void BtnRetroceso_Click(object sender, EventArgs e)
        {
            try
            {
                if (transaccionActiva)
                {
                    currentTransaction?.Rollback();
                    transaccionActiva = false;
                    currentTransaction = null;
                }

                MessageBox.Show("Cambios cancelados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar: " + ex.Message);
            }

            connection.Close();
            this.Close();
        }

        /// <summary>
        /// Evento que se activa al cambiar la selección de materia o sección.
        /// Actualiza el DataGridView con las notas correspondientes.
        /// </summary>
        private void ComboBoxes_SelectionChanged(object? sender, EventArgs? e)
        {
            if (actualizandoSecciones) return;

            if (comboBoxMateria.SelectedItem is not DataRowView materiaRow ||
                comboBoxSeccion.SelectedItem is not DataRowView seccionRow)
                return;

            int selectedMateriaId = (int)materiaRow["id"];
            int selectedSeccionId = (int)seccionRow["id"];

            var sql = loader.BuildSql("notas_por_materia_y_seccion");

            var parameters = new[]
            {
                new NpgsqlParameter("@materia", selectedMateriaId),
                new NpgsqlParameter("@seccion", selectedSeccionId)
            };

            DataTable dt;
            try
            {
                dt = db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar la consulta: {ex.Message}");
                return;
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();
                var gridRow = dataGridView1.Rows[rowIndex];

                gridRow.Cells["Estudiante"].Value = row["estudiante"];
                gridRow.Cells["CI"].Value = row["cedula"];
                gridRow.Cells["Seccion"].Value = row["seccion"];

                gridRow.Cells["NotaFinal"].Value =
                    row["nota_final"] is DBNull or null ? "—" : string.Format("{0:0.0}", row["nota_final"]);

                for (int i = 1; i <= 6; i++)
                {
                    string key = $"n{i}";
                    string col = $"N{i}";
                    var raw = row[key];
                    gridRow.Cells[col].Value = raw is DBNull or null ? "—" : string.Format("{0:0.0}", raw);
                }

                gridRow.Cells["Anadir"].Value = Properties.Resources.BotonAdd;
                gridRow.Cells["Edit"].Value = Properties.Resources.BotonEditar;
            }

            if (dt.Rows.Count == 0)
                MessageBox.Show("No se encontraron notas para la materia y sección seleccionadas.");

            dataGridView1.Refresh();
        }

        /// <summary>
        /// Evento que se activa al hacer clic en una celda del DataGridView.
        /// Permite editar o agregar notas para el estudiante seleccionado.
        /// </summary>
        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            string cedula = row.Cells["CI"].Value?.ToString() ?? "";
            int idPersona = GetPersonaIdByCedula(cedula);

            if (comboBoxMateria.SelectedItem is not DataRowView materiaView ||
                comboBoxSeccion.SelectedItem is not DataRowView seccionView)
                return;

            int materiaId = (int)materiaView["id"];
            int seccionId = (int)seccionView["id"];
            int cursoId = GetCursoId(materiaId, seccionId);
            int numero = GetFirstEmptyNumber(row);

            if (!transaccionActiva)
            {
                currentTransaction = connection.BeginTransaction();
                transaccionActiva = true;
            }

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                var editForm = new EditarNotasForm(db, loader, idPersona, cursoId, connection, currentTransaction!);
                editForm.ShowDialog();
                ComboBoxes_SelectionChanged(null, null);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Anadir"].Index)
            {
                if (numero == 8)
                {
                    MessageBox.Show("Este estudiante ya tiene todas las notas registradas.");
                    return;
                }

                var agregarForm = new CrearNotaForm(idPersona, cursoId, numero, db, loader, currentTransaction!);
                agregarForm.ShowDialog();
                ComboBoxes_SelectionChanged(null, null);
            }
        }

        /// <summary>
        /// Obtiene el primer número de nota vacío en la fila del estudiante.
        /// </summary>
        /// <param name="row">Fila del DataGridView correspondiente al estudiante.</param>
        /// <returns>Número ordinal de la nota vacía, o 8 si todas están llenas.</returns>
        private int GetFirstEmptyNumber(DataGridViewRow row)
        {
            string[] nombres = { "n1", "n2", "n3", "n4", "n5", "n6", "n7" };

            for (int i = 0; i < nombres.Length; i++)
            {
                var celda = row.Cells[nombres[i]].Value;

                bool estaVacia =
                    celda == null ||
                    celda == DBNull.Value ||
                    string.IsNullOrWhiteSpace(celda.ToString()) ||
                    !double.TryParse(celda.ToString(), out _);

                if (estaVacia)
                    return i + 1;
            }

            return 8;
        }

        /// <summary>
        /// Obtiene el ID de la persona a partir de su cédula.
        /// </summary>
        /// <param name="cedula">Cédula del estudiante.</param>
        /// <returns>ID de la persona si existe, -1 en caso contrario.</returns>
        private int GetPersonaIdByCedula(string cedula)
        {
            string sql = loader.BuildSql("buscar_persona_por_cedula");

            var parameters = new[]
            {
                new NpgsqlParameter("@cedula", cedula)
            };

            DataTable dt = db.ExecuteQuery(sql, parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["id"]) : -1;
        }

        /// <summary>
        /// Obtiene el ID del curso a partir de los IDs de materia y sección.
        /// </summary>
        /// <param name="materiaId">ID de la materia.</param>
        /// <param name="seccionId">ID de la sección.</param>
        /// <returns>ID del curso si existe, -1 en caso contrario.</returns>
        private int GetCursoId(int materiaId, int seccionId)
        {
            string sql = loader.BuildSql("get_curso_por_materia_y_seccion");

            var parameters = new[]
            {
                new NpgsqlParameter("@materia", materiaId),
                new NpgsqlParameter("@seccion", seccionId)
            };

            DataTable dt = db.ExecuteQuery(sql, parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["id"]) : -1;
        }

        /// <summary>
        /// Evento que se activa al cambiar la materia seleccionada.
        /// Actualiza el combo de secciones disponibles y refresca las notas.
        /// </summary>
        private void comboBoxMateria_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxMateria.SelectedItem is not DataRowView materiaRow)
                return;

            int idMateria = (int)materiaRow["id"];
            string sql = loader.BuildSql("secciones_por_materia");

            var parameters = new[] {
                new NpgsqlParameter("@materia", idMateria)
            };
            actualizandoSecciones = true;

            DataTable seccionesDisponibles = db.ExecuteQuery(sql, parameters);
            comboBoxSeccion.DataSource = seccionesDisponibles;
            comboBoxSeccion.DisplayMember = "nombre";
            comboBoxSeccion.ValueMember = "id";

            if (seccionesDisponibles.Rows.Count > 0)
                comboBoxSeccion.SelectedIndex = 0;

            actualizandoSecciones = false;

            ComboBoxes_SelectionChanged(null, null);
        }

        /// <summary>
        /// Inicializa los combos de materia y sección con los valores disponibles.
        /// </summary>
        private void InitComboBoxes()
        {
            LoadComboBoxes();

            comboBoxMateria.SelectedIndexChanged += comboBoxMateria_SelectedIndexChanged;
            comboBoxSeccion.SelectedIndexChanged += ComboBoxes_SelectionChanged;

            comboBoxMateria.SelectedIndex = 0;
        }
    }
}
