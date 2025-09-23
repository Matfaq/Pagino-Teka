using Pagino_Teka.Services;

namespace Pagino_Teka
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicjalizacja bazy danych
            DatabaseService.Instance.Initialize();
            // Aktualizacja bazy jeœli potrzeba (dodanie brakuj¹cych tabel)
            DatabaseService.Instance.UpgradeDatabaseIfNeeded();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}