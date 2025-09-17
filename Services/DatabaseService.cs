using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace Pagino_Teka.Services
{
    public class DatabaseService
    {
        private static DatabaseService? _instance;
        private SqliteConnection? _connection;
        private string _dbPath = string.Empty;
        private string _appFolder = string.Empty;

        public static DatabaseService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseService();
                return _instance;
            }
        }

        private DatabaseService() { }

        public void Initialize()
        {
            // 1. Katalog aplikacji w folderze użytkownika
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _appFolder = Path.Combine(userFolder, "Pagino-Teka");
            Directory.CreateDirectory(_appFolder);

            // 2. Katalogi obrazów
            string imagesFolder = Path.Combine(_appFolder, "Images");
            string filmFolder = Path.Combine(imagesFolder, "film_posters");
            string bookFolder = Path.Combine(imagesFolder, "book_covers");

            Directory.CreateDirectory(imagesFolder);
            Directory.CreateDirectory(filmFolder);
            Directory.CreateDirectory(bookFolder);

            // 3. Ścieżka do bazy
            _dbPath = Path.Combine(_appFolder, "pa-te.db");

            // 4. Jeśli brak bazy → utwórz
            if (!File.Exists(_dbPath))
            {
                CreateDatabase();
            }

            // 5. Połączenie
            _connection = new SqliteConnection($"Data Source={_dbPath}");
            _connection.Open();

            // 6. PRAGMA
            using var pragmaCmd = _connection.CreateCommand();
            pragmaCmd.CommandText = @"
                PRAGMA journal_mode = WAL;
                PRAGMA synchronous = NORMAL;
                PRAGMA temp_store = MEMORY;
                PRAGMA foreign_keys = ON;
            ";
            pragmaCmd.ExecuteNonQuery();
        }

        private void CreateDatabase()
        {
            try
            {
                string schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Schema.sql");
                string schemaSql = File.ReadAllText(schemaPath);

                using var connection = new SqliteConnection($"Data Source={_dbPath}");
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = schemaSql;
                command.ExecuteNonQuery();

                MessageBox.Show("Utworzono nową bazę danych.",
                    "Informacja", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas tworzenia bazy danych:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        // --- QUERY METHODS ---

        public DataTable ExecuteQuery(string sql, params SqliteParameter[] parameters)
        {
            if (_connection == null)
                throw new InvalidOperationException("Baza danych nie została zainicjalizowana.");

            using var cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            using var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        /// <summary>
        /// Asynchroniczna wersja ExecuteQuery
        /// </summary>
        public async Task<DataTable> ExecuteQueryAsync(string sql, params SqliteParameter[] parameters)
        {
            if (_connection == null)
                throw new InvalidOperationException("Baza danych nie została zainicjalizowana.");

            using var cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            using var reader = await cmd.ExecuteReaderAsync();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public int ExecuteNonQuery(string sql, params SqliteParameter[] parameters)
        {
            if (_connection == null)
                throw new InvalidOperationException("Baza danych nie została zainicjalizowana.");

            using var cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            return cmd.ExecuteNonQuery();
        }

        public object? ExecuteScalar(string sql, params SqliteParameter[] parameters)
        {
            if (_connection == null)
                throw new InvalidOperationException("Baza danych nie została zainicjalizowana.");

            using var cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            return cmd.ExecuteScalar();
        }

        // --- PATHS ---
        public string GetAppFolderPath() => _appFolder;
        public string GetDatabasePath() => _dbPath;
    }
}
