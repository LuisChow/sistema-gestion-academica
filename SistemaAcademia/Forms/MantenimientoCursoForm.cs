using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla que permite visualizar, buscar, crear y eliminar cursos académicos.
    /// Usa un grid personalizado con campos clave y filtros por materia.
    /// </summary>
    public partial class MantenimientoCursoForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;

        /// <summary>
        /// Constructor principal del formulario.
        /// Recibe componentes necesarios para interacción con la base y generación de SQL.
        /// </summary>
        public MantenimientoCursoForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
            this.Load += MantenimientoCursoForm_Load;
        }

        /// <summary>
        /// Evento al cargar el formulario. Configura el grid y los eventos del buscador.
        /// </summary>
        private void MantenimientoCursoForm_Load(object? sender, EventArgs e)
        {
            LoadCursosInGrid();
            SearchBox.Click += SearchBox_Click;
            SearchBox.KeyDown += SearchBox_KeyDown;
            gridCursos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridCursos.CellValueChanged += gridCursos_CellValueChanged;
            gridCursos.CellClick += gridCursos_CellClick;
            gridCursos.CurrentCellDirtyStateChanged += (s, ev) =>
            {
                if (gridCursos.IsCurrentCellDirty)
                    gridCursos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        /// <summary>
        /// Crea y abre el formulario para registrar un nuevo curso.
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var crearForm = new CrearCursoForm(db, loader))
            {
                crearForm.ShowDialog();
            }
            LoadCursosInGrid(); // Refresca el grid después de agregar
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en una celda del grid.
        /// Si es la columna de edición, abre el formulario para editar el curso.
        /// </summary>
        private void gridCursos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || gridCursos.Columns[e.ColumnIndex].Name != "Edit")
                return;

            var fila = gridCursos.Rows[e.RowIndex];
            if (fila.DataBoundItem is DataRowView drv &&
                drv.Row.Table.Columns.Contains("id") &&
                drv["id"] != DBNull.Value &&
                int.TryParse(drv["id"].ToString(), out int idCurso))
            {
                using var editarForm = new EditarCursoForm(db, loader, idCurso);
                editarForm.ShowDialog();
                LoadCursosInGrid();
            }
            else
            {
                MessageBox.Show("No se pudo determinar el curso a editar.");
            }
        }

        /// <summary>
        /// Ejecuta el borrado de cursos seleccionados en el grid.
        /// Aplica confirmación visual y transacción segura.
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var seleccionados = GetCheckedCursoIDs();
            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un curso para borrar.");
                return;
            }

            DialogResult r = MessageBox.Show(
                $"¿Seguro que desea borrar {seleccionados.Count} curso(s)?",
                "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r != DialogResult.Yes)
                return;

            try
            {
                db.BeginTransaction();

                foreach (int idCurso in seleccionados)
                {
                    var baseParametros = new[] { new NpgsqlParameter("@id", idCurso) };

                    string sqlHorarios = loader.BuildSql("eliminar_horarios_por_curso");
                    db.ExecuteNonQuery(sqlHorarios, db.CloneParameter(baseParametros));

                    string sqlCurso = loader.BuildSql("borrar_curso_por_id");
                    db.ExecuteNonQuery(sqlCurso, db.CloneParameter(baseParametros));
                }

                db.Commit();
                MessageBox.Show("Cursos borrados correctamente.");
                LoadCursosInGrid();
            }
            catch (Exception ex)
            {
                db.Rollback();
                MessageBox.Show("Error al borrar cursos: " + ex.Message);
            }
        }

        /// <summary>
        /// Carga todos los cursos en el grid principal usando el bloque 'cursos_todos'.
        /// Aplica bindings visuales y validación básica.
        /// </summary>
        private void LoadCursosInGrid()
        {
            string sql = loader.BuildSql("cursos_todos");
            DataTable dt = db.ExecuteQuery(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay cursos registrados.");
                gridCursos.DataSource = null;
                return;
            }

            if (!dt.Columns.Contains("id"))
            {
                MessageBox.Show("La consulta 'cursos_todos' debe incluir la columna 'id'.");
                return;
            }

            gridCursos.AutoGenerateColumns = false;

            if (!gridCursos.Columns.Contains("Seleccionar"))
            {
                var colSelect = new DataGridViewCheckBoxColumn
                {
                    Name = "Seleccionar",
                    HeaderText = "✔",
                    Width = 40,
                    ReadOnly = false,
                    TrueValue = true,
                    FalseValue = false
                };
                gridCursos.Columns.Insert(0, colSelect);
            }

            gridCursos.Columns["IDMateria"].DataPropertyName = "codigo_materia";
            gridCursos.Columns["IDMateria"].Width = 80;
            gridCursos.Columns["Materia"].DataPropertyName = "materia";
            gridCursos.Columns["Sección"].DataPropertyName = "seccion";
            gridCursos.Columns["Sección"].Width = 55;
            gridCursos.Columns["Profesor"].DataPropertyName = "profesor";
            gridCursos.Columns["Periodo"].DataPropertyName = "periodo";
            gridCursos.Columns["Horario"].DataPropertyName = "horario";
            gridCursos.Columns["Horario"].Width = 140;
            gridCursos.Columns["Aula"].DataPropertyName = "aula";
            gridCursos.Columns["Cupo"].DataPropertyName = "cupo";
            gridCursos.Columns["Cupo"].Width = 45;

            gridCursos.DataSource = dt;
            gridCursos.ClearSelection();
            gridCursos.ReadOnly = false;
            gridCursos.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            gridCursos.AllowUserToAddRows = false;
            gridCursos.Columns["Seleccionar"].ReadOnly = false;
        }

        /// <summary>
        /// Carga en el grid los cursos filtrados por materia. 
        /// Usa el mismo modelo de columnas que la carga principal.
        /// </summary>
        public void ShowFilteredCursos(DataTable dt)
        {
            gridCursos.DataSource = null;
            gridCursos.Rows.Clear();
            gridCursos.Refresh();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron cursos con ese filtro.");
                return;
            }

            gridCursos.AutoGenerateColumns = false;
            gridCursos.Columns["Materia"].DataPropertyName = "materia";
            gridCursos.Columns["Sección"].DataPropertyName = "seccion";
            gridCursos.Columns["Profesor"].DataPropertyName = "profesor";
            gridCursos.Columns["Periodo"].DataPropertyName = "periodo";
            gridCursos.Columns["Horario"].DataPropertyName = "horario";
            gridCursos.Columns["Aula"].DataPropertyName = "aula";
            gridCursos.Columns["Cupo"].DataPropertyName = "cupo";

            gridCursos.DataSource = dt;
            gridCursos.ClearSelection();
            gridCursos.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            if (gridCursos.Columns.Contains("Seleccionar"))
                gridCursos.Columns["Seleccionar"].ReadOnly = false;

            MessageBox.Show($"Se encontraron {dt.Rows.Count} curso(s).");
        }

        /// <summary>
        /// Evento que ejecuta la búsqueda al presionar Enter dentro del campo buscador.
        /// </summary>
        private void SearchBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchBox_Click(sender, e);
            }
        }

        /// <summary>
        /// Ejecuta la búsqueda de cursos según el texto ingresado en el campo buscador.
        /// Aplica filtro por nombre de materia usando el bloque 'curso_por_materia'.
        /// </summary>
        private void SearchBox_Click(object? sender, EventArgs e)
        {
            string criterio = SearchBox.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show("Ingrese un nombre de materia para buscar.");
                return;
            }

            var parametros = new List<NpgsqlParameter> {
                new("@materia", criterio)
            };

            string sql = loader.BuildSql("curso_por_materia", parametros);
            DataTable resultado = db.ExecuteQuery(sql, parametros.ToArray());

            ShowFilteredCursos(resultado);
        }

        /// <summary>
        /// Evento que resalta visualmente la fila marcada al activar o desactivar la casilla de selección.
        /// </summary>
        private void gridCursos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (gridCursos.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            var fila = gridCursos.Rows[e.RowIndex];
            bool seleccionado = fila.Cells["Seleccionar"].Value is true;

            fila.DefaultCellStyle.BackColor = seleccionado ? Color.LightSkyBlue : Color.White;
        }

        /// <summary>
        /// Obtiene el listado de IDs de cursos seleccionados en el grid.
        /// Extrae los valores desde el DataBoundItem vinculado a cada fila.
        /// </summary>
        private List<int> GetCheckedCursoIDs()
        {
            var ids = new List<int>();

            foreach (DataGridViewRow row in gridCursos.Rows)
            {
                if (row.Cells["Seleccionar"]?.Value is bool seleccionado && seleccionado)
                {
                    if (row.DataBoundItem is DataRowView drv &&
                        drv.Row.Table.Columns.Contains("id") &&
                        drv["id"] != DBNull.Value &&
                        int.TryParse(drv["id"].ToString(), out int id))
                    {
                        ids.Add(id);
                    }
                }
            }

            return ids;
        }

        /// <summary>
        /// Cierra el formulario de mantenimiento
        /// </summary>
        private void BtnBack_Click(object sender, EventArgs e) 
        { 
            this.Close(); 
        }
    }
}