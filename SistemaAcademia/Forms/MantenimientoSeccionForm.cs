using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Formulario para el mantenimiento de secciones académicas.
    /// Permite crear, borrar y visualizar secciones en la base de datos.
    /// </summary>
    public partial class MantenimientoSeccionForm : Form
    {
        private readonly JsonLoader loader;
        private readonly DBComponent db;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="MantenimientoSeccionForm"/>
        /// </summary>
        /// <param name="dbComponent">Componente de base de datos para operaciones SQL.</param>
        /// <param name="jsonLoader">Cargador de bloques SQL definidos en JSON.</param>
        /// <exception cref="ArgumentNullException">Si algún parámetro es nulo.</exception>
        public MantenimientoSeccionForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
            this.Load += MantenimientoSeccionForm_Load;
        }

        /// <summary>
        /// Evento de carga del formulario. Inicializa la grilla y sus eventos.
        /// </summary>
        private void MantenimientoSeccionForm_Load(object? sender, EventArgs e)
        {
            LoadSecciones();
            gridSeccion.CellValueChanged += gridSeccion_CellValueChanged;
            gridSeccion.CurrentCellDirtyStateChanged += gridSeccion_CurrentCellDirtyStateChanged;
        }

        /// <summary>
        /// Cierra el formulario actual.
        /// </summary>
        private void BtnRetroceso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Obtiene los IDs de las secciones seleccionadas en la grilla.
        /// </summary>
        /// <returns>Lista de IDs de secciones marcadas.</returns>
        private List<int> GetCheckedSeccionIDs()
        {
            var ids = new List<int>();

            foreach (DataGridViewRow fila in gridSeccion.Rows)
            {
                if (fila.Cells["Seleccionar"] is DataGridViewCheckBoxCell check &&
                    check.Value is bool marcado && marcado)
                {
                    object raw = fila.Cells["ID"].Value;
                    if (raw != null && int.TryParse(raw.ToString(), out int id))
                        ids.Add(id);
                }
            }

            return ids;
        }

        /// <summary>
        /// Elimina las secciones seleccionadas tras confirmación del usuario.
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var seleccionados = GetCheckedSeccionIDs();

            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una sección para borrar.");
                return;
            }

            DialogResult r = MessageBox.Show(
                $"¿Seguro que desea borrar {seleccionados.Count} sección(es)?",
                "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            try
            {
                db.BeginTransaction();

                foreach (int id in seleccionados)
                {
                    string sql = loader.BuildSql("borrar_seccion_por_id");
                    db.ExecuteNonQuery(sql, new[] { new NpgsqlParameter("@id", id) });
                }

                db.Commit();
                MessageBox.Show("Secciones borradas correctamente.");
                LoadSecciones();
            }
            catch (Exception ex)
            {
                db.Rollback();
                MessageBox.Show("Error al borrar secciones: " + ex.Message);
            }
        }

        /// <summary>
        /// Guarda una nueva sección en la base de datos tras validar el nombre.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreSeccion.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la sección es obligatorio.");
                return;
            }

            if (nombre.Length != 1 || !char.IsLetter(nombre[0]))
            {
                MessageBox.Show("La sección debe ser una sola letra (A-Z).");
                return;
            }

            try
            {
                string existeSql = loader.BuildSql("seccion_existente_por_nombre");
                var paramExiste = new[] { new NpgsqlParameter("@nombre", nombre) };
                DataTable existe = db.ExecuteQuery(existeSql, paramExiste);

                if (existe.Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe una sección con ese nombre.");
                    return;
                }

                string insertarSql = loader.BuildSql("insertar_seccion");
                var paramInsertar = new[] { new NpgsqlParameter("@nombre", nombre) };

                int filas = db.ExecuteNonQuery(insertarSql, paramInsertar);

                if (filas > 0)
                {
                    MessageBox.Show("Sección creada correctamente.");
                    txtNombreSeccion.Clear();
                    LoadSecciones();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar la sección.");
                }
            }
            catch (PostgresException pgEx) when (pgEx.SqlState == "23505")
            {
                MessageBox.Show("Ya existe una sección con ese nombre (clave duplicada).");
            }
            catch (PostgresException pgEx)
            {
                MessageBox.Show($"Error de PostgreSQL:\n{pgEx.Message}\nCódigo: {pgEx.SqlState}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado:\n{ex.Message}");
            }
        }

        /// <summary>
        /// Cambia el color de fondo de la fila según el estado del checkbox "Seleccionar".
        /// </summary>
        private void gridSeccion_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (gridSeccion.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            var fila = gridSeccion.Rows[e.RowIndex];
            bool seleccionado = fila.Cells["Seleccionar"].Value is true;

            fila.DefaultCellStyle.BackColor = seleccionado ? Color.LightGoldenrodYellow : Color.White;
        }

        /// <summary>
        /// Confirma la edición del checkbox cuando cambia el estado de la celda.
        /// </summary>
        private void gridSeccion_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (gridSeccion.IsCurrentCellDirty)
                gridSeccion.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// Carga todas las secciones desde la base de datos y las muestra en la grilla.
        /// </summary>
        private void LoadSecciones()
        {
            string sql = loader.BuildSql("secciones_todas");
            DataTable dt = db.ExecuteQuery(sql);

            gridSeccion.AutoGenerateColumns = false;

            if (!gridSeccion.Columns.Contains("Seleccionar"))
            {
                var colCheck = new DataGridViewCheckBoxColumn
                {
                    Name = "Seleccionar",
                    HeaderText = "",
                    Width = 40
                };
                gridSeccion.Columns.Insert(0, colCheck);
            }

            gridSeccion.Columns["ID"].DataPropertyName = "id";
            gridSeccion.Columns["Seccion"].DataPropertyName = "nombre";

            gridSeccion.DataSource = dt;
            gridSeccion.ClearSelection();

            gridSeccion.ReadOnly = false;
            gridSeccion.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            gridSeccion.AllowUserToAddRows = false;
            gridSeccion.Columns["Seleccionar"].ReadOnly = false;
        }
    }
}
