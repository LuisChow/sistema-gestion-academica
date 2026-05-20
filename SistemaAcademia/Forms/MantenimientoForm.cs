using SistemaAcademia.Components;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla central de navegación para acceder a los formularios de mantenimiento de entidades académicas.
    /// Incluye botones hacia personas, materias, secciones y cursos.
    /// </summary>
    public partial class MantenimientoForm : Form
    {
        private DBComponent db = null!;
        private JsonLoader loader = null!;

        /// <summary>
        /// Constructor principal del formulario.
        /// Recibe el componente de base de datos y el cargador de consultas JSON.
        /// </summary>
        /// <param name="dbComponent">Instancia del componente para ejecutar consultas SQL.</param>
        /// <param name="jsonLoader">Instancia del cargador que genera SQL a partir de bloques JSON.</param>
        public MantenimientoForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
        }

        /// <summary>
        /// Cierra el formulario actual y retorna al contexto anterior.
        /// </summary>
        private void BtnRetroceso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Navega al formulario de mantenimiento de personas (estudiantes y profesores).
        /// Oculta esta pantalla durante la operación y la restaura al cerrar el destino.
        /// </summary>
        private void BtnPersona_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mantenimientoPersonaForm = new MantenimientoPersonaForm(db, loader);
            mantenimientoPersonaForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Navega al formulario de mantenimiento de materias académicas.
        /// Oculta esta pantalla durante la operación y la restaura al cerrar el destino.
        /// </summary>
        private void BtnMateria_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mantenimientoMateriaForm = new MantenimientoMateriaForm(db, loader);
            mantenimientoMateriaForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Navega al formulario de mantenimiento de secciones académicas.
        /// Oculta esta pantalla durante la operación y la restaura al cerrar el destino.
        /// </summary>
        private void BtnSeccion_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mantenimientoSeccionForm = new MantenimientoSeccionForm(db, loader);
            mantenimientoSeccionForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Navega al formulario de mantenimiento de cursos activos.
        /// Oculta esta pantalla durante la operación y la restaura al cerrar el destino.
        /// </summary>
        private void BtnCurso_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var cursoForm = new MantenimientoCursoForm(db, loader);
            cursoForm.ShowDialog();
            this.Show();
        }
    }
}
