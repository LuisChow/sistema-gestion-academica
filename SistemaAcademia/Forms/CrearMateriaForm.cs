using Npgsql;
using SistemaAcademia.Components;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla de creación de nuevas materias académicas.
    /// Permite registrar código, nombre, unidades crédito y trimestre correspondiente.
    /// </summary>
    public partial class CrearMateriaForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;

        /// <summary>
        /// Constructor de la pantalla. Requiere el componente de base de datos y el cargador de bloques SQL.
        /// </summary>
        /// <param name="dbComponent">Conector para operaciones en la base de datos.</param>
        /// <param name="jsonLoader">Instancia del cargador de consultas definidas en JSON.</param>
        public CrearMateriaForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
        }

        /// <summary>
        /// Evento principal de guardado. Valida campos y registra la materia en la base de datos.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Lectura y limpieza de campos
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtMateria.Text.Trim();
            string hcTexto = txtHC.Text.Trim();
            string trimestre = txtTrimestre.Text.Trim();

            // Validación de presencia de campos
            if (string.IsNullOrWhiteSpace(codigo) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(hcTexto) ||
                string.IsNullOrWhiteSpace(trimestre))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Validación de unidad de crédito como número entero positivo
            if (!int.TryParse(hcTexto, out int unidadCredito) || unidadCredito <= 0)
            {
                MessageBox.Show("Las unidades crédito deben ser un número entero positivo.");
                return;
            }

            // Armado de parámetros para el bloque SQL
            var parametros = new List<NpgsqlParameter>
            {
                new("@codigo", codigo),
                new("@nombre", nombre),
                new("@unidad_credito", unidadCredito),
                new("@trimestre", trimestre)
            };

            try
            {
                db.BeginTransaction();

                // Ejecución del insert
                string sql = loader.BuildSql("insertar_materia");
                int filas = db.ExecuteNonQuery(sql, parametros.ToArray());

                db.Commit();

                // Confirmación visual
                if (filas > 0)
                {
                    MessageBox.Show("Materia creada exitosamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar la materia.");
                }
            }
            catch (Exception ex)
            {
                db.Rollback();
                MessageBox.Show("Error al guardar materia: " + ex.Message);
            }
        }
    }
}
