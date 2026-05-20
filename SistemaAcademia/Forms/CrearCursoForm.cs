using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla de creación de cursos. Permite asignar una materia, sección, docente, periodo y hasta tres horarios.
    /// Inserta el curso en la base de datos y vincula los horarios seleccionados.
    /// </summary>
    public partial class CrearCursoForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;

        /// <summary>
        /// Constructor de la pantalla. Recibe el componente de base de datos y el cargador de consultas.
        /// </summary>
        public CrearCursoForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
            this.Load += CrearCursoForm_Load;
        }

        /// <summary>
        /// Evento de carga de la pantalla. Inicializa combos de materias, docentes, horarios y vincula eventos.
        /// </summary>
        private void CrearCursoForm_Load(object? sender, EventArgs e)
        {
            LoadMaterias();
            LoadDocentes();
            LoadFreeHorarios();

            comboMateria.SelectedIndexChanged += (s, ev) =>
            {
                if (comboMateria.SelectedValue is int idMateria)
                {
                    DataRowView? materiaRow = comboMateria.SelectedItem as DataRowView;
                    string? Materia = materiaRow?["nombre"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(Materia))
                        FilterSeccionesByMateria(Materia);
                }
            };
        }

        /// <summary>
        /// Carga los docentes disponibles en el combo, usando el bloque 'docentes_disponibles'.
        /// </summary>
        private void LoadDocentes()
        {
            string sql = loader.BuildSql("docentes_disponibles");
            DataTable dt = db.ExecuteQuery(sql);

            comboDocente.DataSource = dt;
            comboDocente.DisplayMember = "nombre_completo";
            comboDocente.ValueMember = "id";
        }

        /// <summary>
        /// Carga las materias disponibles en el combo, usando el bloque 'combo_materias'.
        /// </summary>
        private void LoadMaterias()
        {
            var dt = db.ExecuteQuery(loader.BuildSql("combo_materias"));
            comboMateria.DataSource = dt;
            comboMateria.DisplayMember = "nombre";
            comboMateria.ValueMember = "id";
        }

        /// <summary>
        /// Valida que todos los campos obligatorios estén completos y que los horarios no estén repetidos.
        /// </summary>
        /// <returns>True si el formulario es válido; False si falta información o hay conflictos.</returns>
        private bool ValidarFormulario()
        {
            if (comboMateria.SelectedValue == null ||
                comboSeccion.SelectedValue == null ||
                comboDocente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione todos los campos obligatorios.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPeriodo.Text))
            {
                MessageBox.Show("Ingrese el periodo académico.");
                return false;
            }

            var horarios = new[] {
                comboDia1.SelectedValue?.ToString(),
                comboDia2.SelectedValue?.ToString(),
                comboDia3.SelectedValue?.ToString()
            };

            if (horarios.Distinct().Count() < horarios.Count(h => !string.IsNullOrWhiteSpace(h)))
            {
                MessageBox.Show("Los horarios seleccionados no pueden repetirse.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Evento de guardado del curso. Inserta el curso y sus horarios en la base de datos dentro de una transacción.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                db.BeginTransaction();

                var parametrosCurso = new List<NpgsqlParameter>
                {
                    new("@materia", comboMateria.SelectedValue),
                    new("@seccion", comboSeccion.SelectedValue),
                    new("@docente", comboDocente.SelectedValue),
                    new("@periodo", txtPeriodo.Text.Trim()),
                    new("@cupo", (int)numCupo.Value)
                };

                string sqlInsertCurso = loader.BuildInsertSql("insertar_curso") + " RETURNING id";

                if (!sqlInsertCurso.StartsWith("INSERT"))
                    throw new InvalidOperationException("El bloque 'insertar_curso' no genera un SQL de tipo INSERT.");

                using var cmdCurso = new NpgsqlCommand(sqlInsertCurso, db.Connection)
                {
                    CommandType = CommandType.Text
                };
                cmdCurso.Parameters.AddRange(parametrosCurso.ToArray());

                object? result = cmdCurso.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    throw new InvalidOperationException("No se pudo obtener el ID del curso recién creado.");

                int nuevoId = Convert.ToInt32(result);

                var horariosIds = new[]
                {
                    comboDia1.SelectedValue,
                    comboDia2.SelectedValue,
                    comboDia3.SelectedValue
                }
                .Where(h => h != null && h != DBNull.Value)
                .Select(h => Convert.ToInt32(h))
                .Distinct();

                string sqlInsertHorarioCurso = loader.BuildInsertSql("insertar_horario_curso");
                if (!sqlInsertHorarioCurso.StartsWith("INSERT"))
                    throw new InvalidOperationException("El bloque 'insertar_horario_curso' no genera un SQL de tipo INSERT.");

                foreach (int idHorario in horariosIds)
                {
                    var parametrosHorario = new List<NpgsqlParameter>
                    {
                        new("@curso", nuevoId),
                        new("@horario", idHorario)
                    };

                    db.ExecuteNonQuery(sqlInsertHorarioCurso, parametrosHorario.ToArray());
                }

                db.Commit();
                MessageBox.Show("Curso creado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                db.Rollback();
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        /// <summary>
        /// Carga los horarios libres en los tres combos y agrega la opción 'sin clase'.
        /// </summary>
        private void LoadFreeHorarios()
        {
            DataTable horarios = db.ExecuteQuery(loader.BuildSql("horarios_libres"));

            var filaVacia = horarios.NewRow();
            filaVacia["id"] = DBNull.Value;
            filaVacia["descripcion"] = "— sin clase —";
            horarios.Rows.InsertAt(filaVacia, 0);

            comboDia1.DataSource = horarios.Copy();
            comboDia1.DisplayMember = "descripcion";
            comboDia1.ValueMember = "id";

            comboDia2.DataSource = horarios.Copy();
            comboDia2.DisplayMember = "descripcion";
            comboDia2.ValueMember = "id";

            comboDia3.DataSource = horarios.Copy();
            comboDia3.DisplayMember = "descripcion";
            comboDia3.ValueMember = "id";
        }

        /// <summary>
        /// Filtra las secciones disponibles para una materia, usando su nombre como parámetro.
        /// </summary>
        /// <param name="nombre">Nombre de la materia seleccionada.</param>
        private void FilterSeccionesByMateria(string nombre)
        {
            var parametros = new List<NpgsqlParameter> { new("@nombre", nombre) };
            string sql = loader.BuildSql("secciones_disponibles_por_nombre", parametros);
            DataTable dt = db.ExecuteQuery(sql, parametros.ToArray());

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Esa materia ya tiene todas las secciones asignadas.");
                comboSeccion.DataSource = null;
                return;
            }

            comboSeccion.DataSource = dt;
            comboSeccion.DisplayMember = "nombre";
            comboSeccion.ValueMember = "id";
        }
    }
}
