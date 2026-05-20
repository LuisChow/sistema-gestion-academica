using Npgsql;
using SistemaAcademia.Components;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla de registro de notas académicas para una persona en un curso específico.
    /// Permite ingresar el número de nota, el valor obtenido y el porcentaje que representa.
    /// </summary>
    public partial class CrearNotaForm : Form
    {
        private readonly int idPersona;
        private readonly int idCurso;
        private readonly int numero;
        private readonly double notaMaxima = 20;
        private readonly double porcentajeMaximo = 100;

        private readonly DBComponent db;
        private readonly JsonLoader loader;
        private readonly NpgsqlTransaction transaction;

        /// <summary>
        /// Constructor del formulario. Recibe identificadores y dependencias necesarias.
        /// </summary>
        /// <param name="idPersona">ID de la persona a quien se asigna la nota.</param>
        /// <param name="idCurso">ID del curso al que pertenece la nota.</param>
        /// <param name="numero">Número ordinal de la nota (por ejemplo, 1°, 2°, etc.).</param>
        /// <param name="db">Componente de base de datos para ejecutar operaciones.</param>
        /// <param name="loader">Instancia del cargador de consultas JSON.</param>
        /// <param name="tx">Transacción activa para mantener coherencia.</param>
        public CrearNotaForm(int idPersona, int idCurso, int numero, DBComponent db, JsonLoader loader, NpgsqlTransaction tx)
        {
            InitializeComponent();

            this.idPersona = idPersona;
            this.idCurso = idCurso;
            this.numero = numero;
            this.db = db;
            this.loader = loader;
            this.transaction = tx;

            BtnGuardar.Click += BtnGuardar_Click;
        }

        /// <summary>
        /// Evento que se activa al hacer clic en "Guardar". 
        /// Valida los valores ingresados y ejecuta la inserción dentro de la transacción recibida.
        /// </summary>
        private void BtnGuardar_Click(object? sender, EventArgs? e)
        {
            // Validación de la nota ingresada (debe estar entre 0 y 20)
            if (!double.TryParse(textBoxNota?.Text, out double nota) || nota < 0 || nota > notaMaxima)
            {
                MessageBox.Show("Ingrese una nota válida entre 0 y 20.");
                return;
            }

            // Validación del porcentaje ingresado (debe estar entre 0 y 100)
            if (!double.TryParse(textBoxPorcentaje?.Text, out double porcentaje) || porcentaje < 0 || porcentaje > porcentajeMaximo)
            {
                MessageBox.Show("Ingrese un porcentaje válido entre 0 y 100.");
                return;
            }

            string sql;
            try
            {
                sql = loader.BuildSql("notas_insertar_nueva");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la consulta desde JSON: {ex.Message}");
                return;
            }

            using var cmd = new NpgsqlCommand(sql, db.Connection, transaction);
            cmd.Parameters.AddWithValue("@persona", idPersona);
            cmd.Parameters.AddWithValue("@curso", idCurso);
            cmd.Parameters.AddWithValue("@numero", numero);
            cmd.Parameters.AddWithValue("@nota", nota);
            cmd.Parameters.AddWithValue("@porcentaje", porcentaje);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Nota agregada correctamente.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la nota.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar la nota: {ex.Message}");
            }
        }
    }
}
