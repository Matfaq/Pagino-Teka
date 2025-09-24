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

        public void UpgradeDatabaseIfNeeded()
        {
            if (_connection == null)
                throw new InvalidOperationException("Baza danych nie została zainicjalizowana.");

            // --- UPGRADE: FilmGenresMap ---
            string checkFilmGenresMapSql = "SELECT name FROM sqlite_master WHERE type='table' AND name='FilmGenresMap';";
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = checkFilmGenresMapSql;
                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    string createTableSql = @"
                        CREATE TABLE IF NOT EXISTS FilmGenresMap (
                            film_id INTEGER NOT NULL,
                            genre_id INTEGER NOT NULL,
                            FOREIGN KEY (film_id) REFERENCES filmy(id),
                            FOREIGN KEY (genre_id) REFERENCES FilmGenres(id),
                            PRIMARY KEY (film_id, genre_id)
                        );";
                    using var createCmd = _connection.CreateCommand();
                    createCmd.CommandText = createTableSql;
                    createCmd.ExecuteNonQuery();

                    MessageBox.Show("Baza danych została zaktualizowana: dodano tabelę FilmGenresMap.",
                        "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // --- UPGRADE: BookGenresMap ---
            string checkBookGenresMapSql = "SELECT name FROM sqlite_master WHERE type='table' AND name='BookGenresMap';";
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = checkBookGenresMapSql;
                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    string createTableSql = @"
                        CREATE TABLE IF NOT EXISTS BookGenresMap (
                            book_id INTEGER NOT NULL,
                            genre_id INTEGER NOT NULL,
                            FOREIGN KEY (book_id) REFERENCES books(id),
                            FOREIGN KEY (genre_id) REFERENCES BookGenres(id),
                            PRIMARY KEY (book_id, genre_id)
                        );";
                    using var createCmd = _connection.CreateCommand();
                    createCmd.CommandText = createTableSql;
                    createCmd.ExecuteNonQuery();

                    // Migracja istniejących danych z books.genre_id
                    string migrateSql = @"
                        INSERT INTO BookGenresMap (book_id, genre_id)
                        SELECT id, genre_id FROM books WHERE genre_id IS NOT NULL;";
                    using var migrateCmd = _connection.CreateCommand();
                    migrateCmd.CommandText = migrateSql;
                    migrateCmd.ExecuteNonQuery();

                    MessageBox.Show("Baza danych została zaktualizowana: dodano tabelę BookGenresMap.",
                        "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        public void CloseConnectionIfOpen()
        {
            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        // --- PATHS ---
        public string GetAppFolderPath() => _appFolder;
        public string GetDatabasePath() => _dbPath;
    }
}
