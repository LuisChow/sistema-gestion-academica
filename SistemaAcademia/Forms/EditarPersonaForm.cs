using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla que permite modificar los datos de una persona previamente registrada.
    /// Carga la información por ID y actualiza los valores seleccionados.
    /// </summary>
    public partial class EditarPersonaForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;
        private readonly int personaId;

        /// <summary>
        /// Constructor principal del formulario. 
        /// Recibe las dependencias necesarias y el ID de la persona a editar.
        /// </summary>
        /// <param name="dbComponent">Instancia conectada del componente de base de datos.</param>
        /// <param name="jsonLoader">Instancia del cargador de bloques SQL.</param>
        /// <param name="id">ID único de la persona que será editada.</param>
        public EditarPersonaForm(DBComponent dbComponent, JsonLoader jsonLoader, int id)
        {
            InitializeComponent();
            db = dbComponent;
            loader = jsonLoader;
            personaId = id;
            this.Load += EditarPersonaForm_Load;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar la pantalla.
        /// Consulta los datos de la persona por su ID y los muestra en los campos.
        /// </summary>
        private void EditarPersonaForm_Load(object? sender, EventArgs e)
        {
            var parametros = new[] { new NpgsqlParameter("@id", personaId) };
            string sql = loader.BuildSql("persona_por_id", parametros.ToList());
            DataTable resultado = db.ExecuteQuery(sql, parametros);

            if (resultado.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la persona.");
                Close();
                return;
            }

            LoadComboTipo();

            var persona = resultado.Rows[0];
            txtCi.Text = persona["cedula"].ToString();
            txtNombre.Text = persona["nombre"].ToString();
            txtApellido.Text = persona["apellido"].ToString();
            ComboTipo.SelectedItem = persona["tipo_persona"].ToString(); // ⚠️ puede requerir mejora si falla por tipo
        }

        /// <summary>
        /// Evento de guardado. 
        /// Valida los campos, construye parámetros y actualiza la persona en la base de datos.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string ci = txtCi.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();

            if (string.IsNullOrWhiteSpace(ci) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                ComboTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            int tipoId = Convert.ToInt32(ComboTipo.SelectedValue);

            var parametros = new List<NpgsqlParameter>
            {
                new("@cedula", ci),
                new("@nombre", nombre),
                new("@apellido", apellido),
                new("@tipo", tipoId),
                new("@id", personaId)
            };

            string sql = loader.BuildSql("update_persona");
            db.ExecuteNonQuery(sql, parametros.ToArray());

            MessageBox.Show("Persona actualizada correctamente.");
            Close();
        }

        /// <summary>
        /// Carga el combo de tipos de persona desde el bloque 'tipos_de_persona2'.
        /// Si no hay datos, muestra alerta y deja el combo sin fuente de datos.
        /// </summary>
        private void LoadComboTipo()
        {
            DataTable tipos = db.ExecuteQuery(loader.BuildSql("tipos_de_persona2"));

            if (tipos == null || tipos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron tipos de persona.");
                ComboTipo.DataSource = null;
                return;
            }

            ComboTipo.DataSource = tipos;
            ComboTipo.DisplayMember = "descripcion";  // texto visible
            ComboTipo.ValueMember = "id";             // valor real utilizado internamente
            ComboTipo.SelectedIndex = -1;
        }
    }
}
