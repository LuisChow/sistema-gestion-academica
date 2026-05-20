using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Formulario para editar los datos de un curso existente.
    /// Permite modificar sección, docente, periodo académico, cupo y horarios asociados.
    /// </summary>
    public partial class EditarCursoForm : Form
    {
        /// <summary>
        /// Componente de base de datos para ejecutar consultas y transacciones.
        /// </summary>
        private readonly DBComponent db;

        /// <summary>
        /// Cargador dinámico de bloques SQL definidos en archivos JSON.
        /// </summary>
        private readonly JsonLoader loader;

        /// <summary>
        /// Identificador único del curso a editar.
        /// </summary>
        private readonly int cursoId;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EditarCursoForm"/>.
        /// </summary>
        /// <param name="dbComponent">Componente de base de datos conectado.</param>
        /// <param name="jsonLoader">Instancia del cargador de bloques SQL.</param>
        /// <param name="id">ID del curso a editar.</param>
        public EditarCursoForm(DBComponent dbComponent, JsonLoader jsonLoader, int id)
        {
            InitializeComponent();
            db = dbComponent;
            loader = jsonLoader;
            cursoId = id;
            this.Load += EditarCursoForm_Load;
        }

        /// <summary>
        /// Evento que se activa al cargar el formulario.
        /// Inicializa los combos y carga los datos actuales del curso.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void EditarCursoForm_Load(object? sender, EventArgs e)
        {
            LoadCombos();

            var parametros = new[] { new NpgsqlParameter("@id", cursoId) };
            string sqlCurso = loader.BuildSql("curso_por_id");
            DataTable resultado = db.ExecuteQuery(sqlCurso, ClonarParametros(parametros));

            if (resultado.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el curso.");
                Close();
                return;
            }

            var curso = resultado.Rows[0];

            comboSeccion.SelectedValue = Convert.ToInt32(curso["id_seccion"]);
            comboDocente.SelectedValue = Convert.ToInt32(curso["id_docente"]);
            txtPeriodo.Text = curso["periodo_academico"]?.ToString() ?? "";
            numCupo.Value = curso["cupo"] != DBNull.Value ? Convert.ToInt32(curso["cupo"]) : 0;

            string sqlDias = loader.BuildSql("dias_por_curso");
            DataTable diasTable = db.ExecuteQuery(sqlDias, ClonarParametros(parametros));
            var descripciones = diasTable.AsEnumerable().Select(r => r["descripcion"].ToString()).ToList();
            comboDia1.Text = descripciones.Count > 0 ? descripciones[0] : "";
            comboDia2.Text = descripciones.Count > 1 ? descripciones[1] : "";
            comboDia3.Text = descripciones.Count > 2 ? descripciones[2] : "";
        }

        /// <summary>
        /// Carga los combos de sección, docente y horarios disponibles.
        /// </summary>
        private void LoadCombos()
        {
            DataTable secciones = db.ExecuteQuery(loader.BuildSql("secciones_activas"));
            comboSeccion.DataSource = secciones;
            comboSeccion.DisplayMember = "nombre";
            comboSeccion.ValueMember = "id";
            comboSeccion.SelectedIndex = -1;

            DataTable docentes = db.ExecuteQuery(loader.BuildSql("docentes_disponibles"));
            comboDocente.DataSource = docentes;
            comboDocente.DisplayMember = "nombre_completo";
            comboDocente.ValueMember = "id";
            comboDocente.SelectedIndex = -1;

            DataTable horarios = db.ExecuteQuery(loader.BuildSql("horarios_libres"));

            comboDia1.DataSource = horarios.Copy();
            comboDia2.DataSource = horarios.Copy();
            comboDia3.DataSource = horarios.Copy();

            comboDia1.DisplayMember = "descripcion";
            comboDia2.DisplayMember = "descripcion";
            comboDia3.DisplayMember = "descripcion";

            comboDia1.ValueMember = "id";
            comboDia2.ValueMember = "id";
            comboDia3.ValueMember = "id";

            comboDia1.SelectedIndex = -1;
            comboDia2.SelectedIndex = -1;
            comboDia3.SelectedIndex = -1;
        }

        /// <summary>
        /// Evento que se activa al hacer clic en el botón de guardar.
        /// Actualiza los datos del curso y sus horarios en la base de datos.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (comboSeccion.SelectedIndex < 0 ||
                comboDocente.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtPeriodo.Text) ||
                numCupo.Value < 1)
            {
                MessageBox.Show("Todos los campos obligatorios deben estar completos.");
                return;
            }

            var parametrosCurso = new[]
            {
                new NpgsqlParameter("@id", cursoId),
                new NpgsqlParameter("@id_seccion", comboSeccion.SelectedValue),
                new NpgsqlParameter("@id_docente", comboDocente.SelectedValue),
                new NpgsqlParameter("@periodo", txtPeriodo.Text.Trim()),
                new NpgsqlParameter("@cupo", (int)numCupo.Value)
            };

            try
            {
                string sqlCurso = loader.BuildSql("update_curso");
                db.ExecuteNonQuery(sqlCurso, ClonarParametros(parametrosCurso));

                var paramId = new[] { new NpgsqlParameter("@id", cursoId) };
                string sqlDelete = loader.BuildSql("eliminar_horarios_por_curso");
                db.ExecuteNonQuery(sqlDelete, ClonarParametros(paramId));

                var horariosIds = new[]
                {
                    comboDia1.SelectedValue,
                    comboDia2.SelectedValue,
                    comboDia3.SelectedValue
                }
                .Where(h => h != null && h != DBNull.Value)
                .Select(h => Convert.ToInt32(h))
                .Distinct();

                string sqlInsert = loader.BuildSql("insertar_horario_curso");

                foreach (int idHorario in horariosIds)
                {
                    var parametrosHorario = new[]
                    {
                        new NpgsqlParameter("@curso", cursoId),
                        new NpgsqlParameter("@horario", idHorario)
                    };
                    db.ExecuteNonQuery(sqlInsert, ClonarParametros(parametrosHorario));
                }

                MessageBox.Show("Curso actualizado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                db.Rollback();
                MessageBox.Show("Error al actualizar curso:\n" + ex.Message);
            }
        }

        /// <summary>
        /// Clona los parámetros de Npgsql para evitar referencias compartidas.
        /// </summary>
        /// <param name="originales">Colección de parámetros originales.</param>
        /// <returns>Arreglo de parámetros clonados.</returns>
        private static NpgsqlParameter[] ClonarParametros(IEnumerable<NpgsqlParameter> originales)
        {
            return originales
                .Select(p => new NpgsqlParameter(p.ParameterName, p.Value))
                .ToArray();
        }
    }
}
