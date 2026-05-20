using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla que permite gestionar todas las materias académicas del sistema.
    /// Ofrece funcionalidades de búsqueda, edición, creación y eliminación.
    /// </summary>
    public partial class MantenimientoMateriaForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;

        /// <summary>
        /// Constructor principal. Recibe componentes de conexión y SQL dinámico.
        /// </summary>
        public MantenimientoMateriaForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
            this.Load += MantenimientoMateriaForm_Load;
        }

        /// <summary>
        /// Configura la pantalla al cargar. Inicializa el grid, eventos de búsqueda y comportamiento visual.
        /// </summary>
        private void MantenimientoMateriaForm_Load(object? sender, EventArgs e)
        {
            LoadMateriasGrid();
            gridMaterias.CellClick += gridMaterias_CellClick;
            SearchBox.Click += SearchBox_Click;
            SearchBox.KeyDown += SearchBox_KeyDown;

            gridMaterias.Columns["IDMateria"].DataPropertyName = "codigo";
            gridMaterias.Columns["Materia"].DataPropertyName = "nombre";
            gridMaterias.Columns["HC"].DataPropertyName = "unidad_credito";
            gridMaterias.Columns["Trimestre"].DataPropertyName = "trimestre";

            gridMaterias.Columns["Edit"].ReadOnly = false;
            gridMaterias.ReadOnly = false;

            foreach (DataGridViewColumn col in gridMaterias.Columns)
            {
                if (col.Name != "Seleccionar")
                    col.ReadOnly = true;
            }

            gridMaterias.CellValueChanged += gridMaterias_CellValueChanged;
            gridMaterias.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (gridMaterias.IsCurrentCellDirty)
                    gridMaterias.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        /// <summary>
        /// Carga todas las materias en el grid principal.
        /// Configura la columna de selección si aún no existe.
        /// </summary>
        private void LoadMateriasGrid()
        {
            if (gridMaterias.Columns["Seleccionar"] == null)
            {
                var colCheck = new DataGridViewCheckBoxColumn
                {
                    Name = "Seleccionar",
                    HeaderText = "",
                    Width = 42
                };
                gridMaterias.Columns.Insert(0, colCheck);
            }

            string sql = loader.BuildSql("materias_todas");
            DataTable dt = db.ExecuteQuery(sql);
            gridMaterias.AutoGenerateColumns = false;
            gridMaterias.DataSource = dt;
        }

        /// <summary>
        /// Evento que cambia el color de la fila si se activa el checkbox de selección.
        /// </summary>
        private void gridMaterias_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (gridMaterias.Columns[e.ColumnIndex].Name != "Seleccionar") return;

            var fila = gridMaterias.Rows[e.RowIndex];
            bool seleccionado = fila.Cells["Seleccionar"].Value is true;
            fila.DefaultCellStyle.BackColor = seleccionado ? Color.Moccasin : Color.White;
        }

        /// <summary>
        /// Lógica que responde al cambio de texto en el buscador.
        /// Ejecuta búsqueda por código y actualiza el grid.
        /// </summary>
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string codigo = SearchBox.Text.Trim();
            var parametros = new[] { new NpgsqlParameter("@codigo", codigo) };
            string sql = loader.BuildSql("buscar_materia_por_codigo", parametros.ToList());
            DataTable resultado = db.ExecuteQuery(sql, parametros);
            gridMaterias.DataSource = resultado;
        }

        /// <summary>
        /// Abre el formulario para crear una nueva materia.
        /// Refresca el grid al cerrar.
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var crear = new CrearMateriaForm(db, loader);
            crear.ShowDialog();
            LoadMateriasGrid();
        }

        /// <summary>
        /// Abre el formulario de edición de materia para el código indicado.
        /// </summary>
        private void OpenEditarMateriaForm(string codigoMateria)
        {
            using var editar = new EditarMateriaForm(db, loader, codigoMateria);
            editar.ShowDialog();
            LoadMateriasGrid();
        }

        /// <summary>
        /// Evento que detecta clic en el botón de edición dentro del grid.
        /// Extrae el código de la materia y abre el editor.
        /// </summary>
        private void gridMaterias_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || gridMaterias.Columns[e.ColumnIndex].Name != "Edit") return;

            var fila = gridMaterias.Rows[e.RowIndex];
            string codigo = fila.Cells["IDMateria"].Value?.ToString() ?? "";
            if (!string.IsNullOrWhiteSpace(codigo))
                OpenEditarMateriaForm(codigo);
        }

        /// <summary>
        /// Extrae los códigos de todas las materias marcadas en el grid.
        /// </summary>
        /// <returns>Lista de códigos seleccionados.</returns>
        private List<string> GetCheckedCodigos()
        {
            var codigos = new List<string>();
            foreach (DataGridViewRow fila in gridMaterias.Rows)
            {
                if (fila.Cells["Seleccionar"] is DataGridViewCheckBoxCell check &&
                    check.Value is bool marcado && marcado)
                {
                    string codigo = fila.Cells["IDMateria"].Value?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(codigo))
                        codigos.Add(codigo);
                }
            }
            return codigos;
        }

        /// <summary>
        /// Ejecuta el borrado de las materias seleccionadas en el grid.
        /// Usa transacción segura y recarga el grid al finalizar.
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var seleccionados = GetCheckedCodigos();

            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una materia para borrar.");
                return;
            }

            DialogResult r = MessageBox.Show(
                $"¿Seguro que desea borrar {seleccionados.Count} materia(s)?",
                "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            try
            {
                db.BeginTransaction();
                foreach (string codigo in seleccionados)
                {
                    var parametros = new[] { new NpgsqlParameter("@codigo", codigo) };
                    string sql = loader.BuildSql("borrar_materia_por_codigo");
                    db.ExecuteNonQuery(sql, parametros);
                }
                db.Commit();
                MessageBox.Show("Materias borradas correctamente.");
                LoadMateriasGrid();
            }
            catch (Exception ex)
            {
                db.Rollback();
                MessageBox.Show("Error al borrar materias: " + ex.Message);
            }
        }

        /// <summary>
        /// Cierra el formulario actual.
        /// </summary>
        private void BtnRetroceso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Ejecuta la búsqueda por código al hacer clic en el campo buscador.
        /// </summary>
        private void SearchBox_Click(object? sender, EventArgs e)
        {
            string codigo = SearchBox.Text?.Trim() ?? "";
            GetMateriaByCode(codigo);
        }

        /// <summary>
        /// Ejecuta la búsqueda por código al presionar ENTER en el campo buscador.
        /// </summary>
        private void SearchBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string codigo = SearchBox.Text?.Trim() ?? "";
                GetMateriaByCode(codigo);
                e.SuppressKeyPress = true; // Evita beep al presionar Enter
            }
        }

        /// <summary>
        /// Realiza la búsqueda por código de materia y actualiza el grid con el resultado.
        /// </summary>
        private void GetMateriaByCode(string codigo)
        {
            var parametros = new[] { new NpgsqlParameter("@codigo", codigo) };
            string sql = loader.BuildSql("buscar_materia_por_codigo", parametros.ToList());
            DataTable resultado = db.ExecuteQuery(sql, parametros);
            gridMaterias.DataSource = resultado;
        }
    }
}
