using Newtonsoft.Json;
using SistemaAcademia.Components;
using System.Text;

namespace SistemaAcademia
{
    /// <summary>
    /// Pantalla principal del sistema académico.
    /// Ofrece acceso a los módulos de notas, reportes, inscripciones y mantenimiento.
    /// Inicializa los componentes desacoplados desde configuración JSON.
    /// </summary>
    public partial class MenuPrincipal : Form
    {
        private DBComponent db = null!;
        private JsonLoader loader = null!;

        /// <summary>
        /// Constructor de la pantalla principal.
        /// Lee las rutas desde el archivo JSON y prepara los componentes necesarios.
        /// Si ocurre algún error crítico, se cierra automáticamente.
        /// </summary>
        public MenuPrincipal()
        {
            InitializeComponent();

            var contexto = GetJson();
            if (contexto is null)
            {
                MessageBox.Show("No se pudo obtener los archivos json.");
                Close();
                return;
            }

            db = contexto.Value.db;
            loader = contexto.Value.loader;
        }

        /// <summary>
        /// Carga y construye el componente de conexión y el loader desde Rutas.json.
        /// Interpreta las claves 'db' y 'Queries_Joins', validando errores comunes.
        /// </summary>
        /// <returns>Tupla (db, loader) si se pudo cargar correctamente; null si falla.</returns>
        private (DBComponent db, JsonLoader loader)? GetJson()
        {
            string rutaConfig = "sql/Rutas.json";
            if (!File.Exists(rutaConfig))
            {
                MessageBox.Show($"No se encontró el archivo de configuración de rutas: {rutaConfig}");
                return null;
            }

            Dictionary<string, string>? rutas;
            try
            {
                string json = File.ReadAllText(rutaConfig, Encoding.UTF8);
                rutas = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al interpretar Rutas.json: {ex.Message}");
                return null;
            }

            if (rutas is null ||
                !rutas.TryGetValue("db", out var rutaDB) ||
                !rutas.TryGetValue("Queries_Joins", out var rutaQueries))
            {
                MessageBox.Show("Las claves 'db' o 'Queries_Joins' faltan en Rutas.json.");
                return null;
            }

            try
            {
                var db = DBComponent.FromSettings(rutaDB);
                var loader = new JsonLoader(rutaQueries);
                return (db, loader);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar componentes desacoplados: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Abre el módulo de gestión de notas.
        /// Oculta temporalmente la pantalla principal y restaura al cerrar el destino.
        /// </summary>
        private void BtnNotas_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var notasForm = new NotasForm(db, loader);
            notasForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Abre el módulo de reportes académicos.
        /// Oculta temporalmente la pantalla principal y restaura al cerrar el destino.
        /// </summary>
        private void BtnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var reportesForm = new ReportesForm(db, loader);
            reportesForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Abre el módulo de inscripciones.
        /// Oculta temporalmente la pantalla principal y restaura al cerrar el destino.
        /// </summary>
        private void BtnInscripcion_Click(object sender, EventArgs e)
        {
            this.Hide();
            using var inscripcionesForm = new InscripcionesForm(db, loader);
            inscripcionesForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Abre el módulo de mantenimiento de entidades académicas.
        /// Oculta temporalmente la pantalla principal y restaura al cerrar el destino.
        /// </summary>
        private void BtnMantenimiento_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mantenimiento = new MantenimientoForm(db, loader);
            mantenimiento.ShowDialog();
            this.Show();
        }
    }
}
