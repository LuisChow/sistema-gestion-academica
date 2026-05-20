using Newtonsoft.Json;

namespace SistemaAcademia
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var rutas = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("sql/Rutas.json"));

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuPrincipal());
        }
    }
}