using SistemaAcademia.Components;

namespace SistemaAcademia
{
    /// <summary>
    /// Formulario principal de reportes del sistema académico.
    /// Permite acceder a la planilla de notas y evaluaciones de estudiantes.
    /// </summary>
    public partial class ReportesForm : Form
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
        /// Inicializa una nueva instancia de <see cref="ReportesForm"/>.
        /// </summary>
        /// <param name="dbComponent">Componente de base de datos para el formulario.</param>
        /// <param name="jsonLoader">Cargador de bloques SQL para el formulario.</param>
        public ReportesForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent;
            loader = jsonLoader;
            BtnRetroceso.Click += BtnRetroceso_Click;
        }

        /// <summary>
        /// Evento click para mostrar la planilla de notas de estudiantes.
        /// Oculta el formulario actual y muestra el formulario de planilla de notas.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnPlanillaNotas_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using (var planillaNotasForm = new PlanillaNotasForm(db, loader))
            {
                planillaNotasForm.ShowDialog();
            }
            this.Show();
        }

        /// <summary>
        /// Evento click para mostrar la planilla de evaluaciones de estudiantes.
        /// Oculta el formulario actual y muestra el formulario de planilla de evaluaciones.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnPlanillaEvaluaciones_Click(object? sender, EventArgs e)
        {
            this.Hide();
            using (var planillaEvaluacionesForm = new PlanillaEvaluacionesForm(db, loader))
            {
                planillaEvaluacionesForm.ShowDialog();
            }
            this.Show();
        }

        /// <summary>
        /// Evento click del botón de retroceso. Cierra el formulario de reportes.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void BtnRetroceso_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
