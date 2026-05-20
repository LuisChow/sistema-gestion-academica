using Npgsql;
using SistemaAcademia.Components;
using System.Data;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla que permite modificar los datos de una materia existente.
    /// Se consulta la materia por su código y se actualiza con nuevos valores.
    /// </summary>
    public partial class EditarMateriaForm : Form
    {
        private readonly DBComponent db;
        private readonly JsonLoader loader;
        private readonly string codigoMateria;

        /// <summary>
        /// Constructor principal. Recibe el componente de base de datos,
        /// el cargador de consultas JSON y el código de la materia a editar.
        /// </summary>
        public EditarMateriaForm(DBComponent dbComponent, JsonLoader jsonLoader, string codigo)
        {
            InitializeComponent();
            db = dbComponent;
            loader = jsonLoader;
            codigoMateria = codigo;
            this.Load += EditarMateriaForm_Load;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar la pantalla. 
        /// Consulta los datos de la materia por su código y los muestra en los campos del formulario.
        /// </summary>
        private void EditarMateriaForm_Load(object? sender, EventArgs e)
        {
            var parametros = new[] { new NpgsqlParameter("@codigo", codigoMateria) };
            string sql = loader.BuildSql("materia_por_codigo", parametros.ToList());
            DataTable resultado = db.ExecuteQuery(sql, parametros);

            if (resultado.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la materia.");
                Close();
                return;
            }

            var materia = resultado.Rows[0];
            txtCodigo.Text = materia["codigo"].ToString();
            txtMateria.Text = materia["nombre"].ToString();
            txtHC.Text = materia["unidad_credito"].ToString();
            txtTrimestre.Text = materia["trimestre"].ToString();
        }

        /// <summary>
        /// Evento que se ejecuta al guardar los cambios.
        /// Valida la entrada del usuario, construye la consulta de actualización y ejecuta el cambio en transacción.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtMateria.Text.Trim();
            string hcTexto = txtHC.Text.Trim();
            string trimestre = txtTrimestre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nuevoNombre) ||
                string.IsNullOrWhiteSpace(hcTexto) ||
                string.IsNullOrWhiteSpace(trimestre))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!int.TryParse(hcTexto, out int unidadCredito) || unidadCredito <= 0)
            {
                MessageBox.Show("HC debe ser un número entero positivo.");
                return;
            }

            var parametros = new List<NpgsqlParameter>
            {
                new("@codigo", codigoMateria),
                new("@nombre", nuevoNombre),
                new("@unidad_credito", unidadCredito),
                new("@trimestre", trimestre)
            };

            try
            {
                db.BeginTransaction();

                string sql = loader.BuildSql("update_materia");
                db.ExecuteNonQuery(sql, parametros.ToArray());

                db.Commit();
                MessageBox.Show("Materia actualizada correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                db.Rollback();
                MessageBox.Show("Error al actualizar materia: " + ex.Message);
            }
        }
    }
}
