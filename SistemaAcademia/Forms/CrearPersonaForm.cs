using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla destinada a la creación de personas en el sistema.
    /// Permite ingresar datos básicos y seleccionar el tipo de persona desde el combo vinculado.
    /// </summary>
    public partial class CrearPersonaForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;

        /// <summary>
        /// Constructor del formulario. Recibe dependencias necesarias para ejecutar consultas.
        /// </summary>
        /// <param name="dbComponent">Instancia del componente de base de datos.</param>
        /// <param name="jsonLoader">Instancia del cargador de bloques JSON SQL.</param>
        public CrearPersonaForm(DBComponent dbComponent, JsonLoader jsonLoader)
        {
            InitializeComponent();
            db = dbComponent ?? throw new ArgumentNullException(nameof(dbComponent));
            loader = jsonLoader ?? throw new ArgumentNullException(nameof(jsonLoader));
            this.Load += CrearPersonaForm_Load;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario. Inicializa el combo de tipo de persona.
        /// </summary>
        private void CrearPersonaForm_Load(object? sender, EventArgs e)
        {
            LoadComboTipoPersona();
        }

        /// <summary>
        /// Evento que se activa al presionar el botón de guardado.
        /// Valida campos obligatorios, prepara parámetros, ejecuta el INSERT y muestra resultado.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string ci = txtCi.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            int? tipoId = ComboTipo.SelectedValue as int?;

            // Validación de obligatoriedad
            if (string.IsNullOrWhiteSpace(ci) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                tipoId == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Armado de parámetros para el bloque SQL
            var parametros = new List<NpgsqlParameter>
            {
                new("@cedula", ci),
                new("@nombre", nombre),
                new("@apellido", apellido),
                new("@id_tipo_persona", tipoId)
            };

            string sql = loader.BuildSql("insertar_persona");
            int filas = db.ExecuteNonQuery(sql, parametros.ToArray());

            if (filas > 0)
            {
                MessageBox.Show("Persona creada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo insertar la persona.");
            }
        }

        /// <summary>
        /// Carga el combo de tipos de persona utilizando el bloque 'tipos_de_persona2'.
        /// Si no hay resultados, muestra alerta. Deja combo sin selección inicial.
        /// </summary>
        private void LoadComboTipoPersona()
        {
            ComboTipo.Items.Clear();

            DataTable tipos = db.ExecuteQuery(loader.BuildSql("tipos_de_persona2"));

            if (tipos == null || tipos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron tipos de persona.");
                return;
            }

            ComboTipo.DataSource = tipos;
            ComboTipo.DisplayMember = "descripcion";
            ComboTipo.ValueMember = "id";
            ComboTipo.SelectedIndex = -1;
        }
    }
}
