using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Formulario para visualizar y consultar la planilla de evaluaciones de estudiantes.
    /// Permite buscar por cédula y mostrar las notas por materia.
    /// </summary>
    public partial class PlanillaEvaluacionesForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="PlanillaEvaluacionesForm"/>.
        /// </summary>
        /// <param name="dbComponent">Componente de base de datos para ejecutar consultas.</param>
        /// <param name="jsonLoader">Cargador de bloques SQL definidos en JSON.</param>
        public PlanillaEvaluacionesForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();

            db = dbComponent;
            loader = jsonLoader;

            ConfigGridGrades();

            SearchBox.Click += SearchBox_Click;
            BtnBack.Click += BtnBack_Click;
            SearchBox.KeyDown += SearchBox_KeyDown;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
        }

        /// <summary>
        /// Busca el ID de una persona en la base de datos usando su cédula.
        /// </summary>
        /// <param name="cedula">Cédula del estudiante.</param>
        /// <returns>ID de la persona si existe; -1 si no se encuentra.</returns>
        private int SearchIdByCedula(string cedula)
        {
            string sql = loader.BuildSql("buscar_persona_por_cedula");
            var parameters = new[] { new NpgsqlParameter("@cedula", cedula) };
            DataTable dt = db.ExecuteQuery(sql, parameters);

            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["id"]) : -1;
        }

        /// <summary>
        /// Evento click del cuadro de búsqueda. Realiza la búsqueda por cédula y muestra las evaluaciones.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void SearchBox_Click(object? sender, EventArgs e)
        {
            string cedula = SearchBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(cedula))
            {
                MessageBox.Show("Por favor ingrese una cédula.");
                return;
            }

            int idPersona = SearchIdByCedula(cedula);

            if (idPersona == -1)
            {
                MessageBox.Show("Estudiante no encontrado.");
                return;
            }

            ShowGrid(idPersona);
        }

        /// <summary>
        /// Evento de teclado en el cuadro de búsqueda. Permite buscar al presionar Enter.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos de la tecla presionada.</param>
        private void SearchBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBox_Click(SearchBox, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Muestra en el grid las evaluaciones del estudiante especificado por su ID.
        /// </summary>
        /// <param name="idPersona">ID del estudiante.</param>
        private void ShowGrid(int idPersona)
        {
            string sql = loader.BuildSql("evaluaciones_por_estudiante");
            var parameters = new[] { new NpgsqlParameter("@id", idPersona) };
            DataTable dt = db.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron evaluaciones registradas.");
                return;
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int index = dataGridView1.Rows.Add();
                var gridRow = dataGridView1.Rows[index];

                gridRow.Cells["Materia"].Value = row["materia"];
                for (int i = 1; i <= 8; i++)
                {
                    string claveSQL = $"n{i}";
                    string nombreColumna = $"N{i}";
                    gridRow.Cells[nombreColumna].Value =
                        row[claveSQL] is DBNull ? "—" : string.Format("{0:0.0}", row[claveSQL]);
                }
            }

            dataGridView1.Refresh();
        }

        /// <summary>
        /// Configura las columnas del grid para mostrar materias y notas.
        /// </summary>
        private void ConfigGridGrades()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Materia",
                HeaderText = "Materia",
                DataPropertyName = "materia"
            });

            for (int i = 1; i <= 8; i++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = $"N{i}",
                    HeaderText = $"N{i}",
                    DataPropertyName = $"n{i}"
                });
            }
        }

        /// <summary>
        /// Evento de formato de celda en el grid. Aplica formato decimal a las notas.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos de formato de celda.</param>
        private void dataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.StartsWith("N"))
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out var val))
                {
                    e.Value = val.ToString("0.0");
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Evento click del botón de regreso. Cierra el formulario actual.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnBack_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
