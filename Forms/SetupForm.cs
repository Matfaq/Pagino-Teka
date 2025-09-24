using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Pagino_Teka.Theme;

namespace Pagino_Teka.Forms
{
    public partial class SetupForm : Form
    {
        private readonly string _appDataPath;
        private string SettingsJsonPath => Path.Combine(_appDataPath, "user_settings.json");
        private string ThemePath => Path.Combine(_appDataPath, "theme.txt");

        private class UserSettings
        {
            public bool UseGoogleApi { get; set; }
            public string GoogleApiKey { get; set; } = string.Empty;
            public bool UseOmdbApi { get; set; }
            public string OmdbApiKey { get; set; } = string.Empty;
        }

        public SetupForm(string appDataPath)
        {
            _appDataPath = appDataPath ?? throw new ArgumentNullException(nameof(appDataPath));
            InitializeComponent();
            try { ThemeManager.ApplyTheme(this); } catch { }
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            try
            {
                checkBox_UseGoogleApi.Checked = false;
                textBox_GoogleApiKey.Text = string.Empty;
                checkBox_UseOmdbApiKey.Checked = false; // Domyślnie odznaczony
                textBox_OmdbApiKey.Text = string.Empty; // Domyślnie pusty
                radioButton_Light.Checked = true;

                if (File.Exists(SettingsJsonPath))
                {
                    var json = File.ReadAllText(SettingsJsonPath);
                    var s = System.Text.Json.JsonSerializer.Deserialize<UserSettings>(json) ?? new UserSettings();
                    checkBox_UseGoogleApi.Checked = s.UseGoogleApi;
                    textBox_GoogleApiKey.Text = s.GoogleApiKey ?? string.Empty;
                    checkBox_UseOmdbApiKey.Checked = s.UseOmdbApi;
                    textBox_OmdbApiKey.Text = s.OmdbApiKey ?? string.Empty;
                }

                UpdateApiKeyTextboxEnabled();
                UpdateOmdbKeyTextboxEnabled();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się wczytać ustawień:\n{ex.Message}",
                    "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateApiKeyTextboxEnabled()
        {
            textBox_GoogleApiKey.Enabled = checkBox_UseGoogleApi.Checked;
        }

        private void UpdateOmdbKeyTextboxEnabled()
        {
            textBox_OmdbApiKey.Enabled = checkBox_UseOmdbApiKey.Checked;
        }

        private void checkBox_UseGoogleApi_CheckedChanged(object sender, EventArgs e)
        {
            UpdateApiKeyTextboxEnabled();
        }

        private void checkBox_UseOmdbApi_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOmdbKeyTextboxEnabled();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(_appDataPath);

                var s = new UserSettings
                {
                    UseGoogleApi = checkBox_UseGoogleApi.Checked,
                    GoogleApiKey = textBox_GoogleApiKey.Text?.Trim() ?? string.Empty,
                    UseOmdbApi = checkBox_UseOmdbApiKey.Checked,
                    OmdbApiKey = textBox_OmdbApiKey.Text?.Trim() ?? string.Empty
                };
                var json = System.Text.Json.JsonSerializer.Serialize(s, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsJsonPath, json);

                var theme = radioButton_Dark.Checked ? "Dark" : "Light";
                File.WriteAllText(ThemePath, theme);

                MessageBox.Show("Ustawienia zapisane.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy zapisie ustawień:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button_LinkConsole_Click(object sender, EventArgs e)
        {
            OpenUrl("https://console.cloud.google.com/");
        }

        private void button_LinkDocs_Click(object sender, EventArgs e)
        {
            OpenUrl("https://developers.google.com/books/docs/overview");
        }

        private static void OpenUrl(string url)
        {
            try
            {
                var psi = new ProcessStartInfo { FileName = url, UseShellExecute = true };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się otworzyć strony:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_OmdbKeyLink_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.omdbapi.com/apikey.aspx"); // panel do wygenerowania klucza
        }

        private void button_DocsOmdbKey_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.omdbapi.com/"); // dokumentacja API
        }

        private void button_ResetFilms_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Ta operacja usunie WSZYSTKIE dane o filmach, reżyserach i scenarzystach!\n" +
                "Tej operacji NIE MOŻNA cofnąć.\n\n" +
                "Przed kontynuacją zostanie utworzona kopia zapasowa bazy danych.\n\n" +
                "Czy na pewno chcesz kontynuować?",
                "Potwierdzenie resetu danych filmowych",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Ścieżka do bazy danych
                string dbPath = Path.Combine(_appDataPath, "pa-te.db");
                if (!File.Exists(dbPath))
                {
                    MessageBox.Show("Nie znaleziono pliku bazy danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tworzenie kopii zapasowej
                string backupPath = Path.Combine(_appDataPath, $"pa-te_backup_{DateTime.Now:yyyyMMdd_HHmmss}.db");
                File.Copy(dbPath, backupPath);

                // Usuwanie danych z tabel filmowych
                using (var connection = new Microsoft.Data.Sqlite.SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;

                        command.CommandText = "DELETE FROM FilmGenresMap;";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM filmy;";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM Directors;";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM Screenwriters;";
                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    $"Dane filmowe zostały usunięte.\nKopia zapasowa bazy: {backupPath}",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Zamknij SetupForm z wynikiem OK, aby MainForm mogła zareagować
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas resetowania danych filmowych:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ResetBooks_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Ta operacja usunie WSZYSTKIE dane o książkach, autorach, wydawcach, cyklach i powiązaniach!\n" +
                "Tej operacji NIE MOŻNA cofnąć.\n\n" +
                "Przed kontynuacją zostanie utworzona kopia zapasowa bazy danych.\n\n" +
                "Czy na pewno chcesz kontynuować?",
                "Potwierdzenie resetu danych książkowych",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string dbPath = Path.Combine(_appDataPath, "pa-te.db");
                if (!File.Exists(dbPath))
                {
                    MessageBox.Show("Nie znaleziono pliku bazy danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tworzenie kopii zapasowej
                string backupPath = Path.Combine(_appDataPath, $"pa-te_backup_books_{DateTime.Now:yyyyMMdd_HHmmss}.db");
                File.Copy(dbPath, backupPath);

                // Usuwanie danych z tabel książkowych (z pominięciem BookGenres)
                using (var connection = new Microsoft.Data.Sqlite.SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;

                        command.CommandText = "DELETE FROM BookGenresMap;";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM books;";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM Authors;";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM Publishers;";
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM BookSeries;";
                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    $"Dane książkowe zostały usunięte.\nKopia zapasowa bazy: {backupPath}",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas resetowania danych książkowych:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ResetAll_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Ta operacja usunie WSZYSTKIE dane o książkach, filmach, autorach, wydawcach, cyklach, reżyserach, scenarzystach i powiązaniach!\n" +
                "Tej operacji NIE MOŻNA cofnąć.\n\n" +
                "Przed kontynuacją zostanie utworzona kopia zapasowa bazy danych.\n\n" +
                "Czy na pewno chcesz kontynuować?",
                "Potwierdzenie pełnego resetu danych",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string dbPath = Path.Combine(_appDataPath, "pa-te.db");
                if (!File.Exists(dbPath))
                {
                    MessageBox.Show("Nie znaleziono pliku bazy danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tworzenie kopii zapasowej
                string backupPath = Path.Combine(_appDataPath, $"pa-te_backup_all_{DateTime.Now:yyyyMMdd_HHmmss}.db");
                File.Copy(dbPath, backupPath);

                using (var connection = new Microsoft.Data.Sqlite.SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;

                        // Książki
                        command.CommandText = "DELETE FROM BookGenresMap;";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM books;";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Authors;";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Publishers;";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM BookSeries;";
                        command.ExecuteNonQuery();

                        // Filmy
                        command.CommandText = "DELETE FROM FilmGenresMap;";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM filmy;";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Directors;";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Screenwriters;";
                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    $"Wszystkie dane zostały usunięte.\nKopia zapasowa bazy: {backupPath}",
                    "Sukces",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas resetowania wszystkich danych:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
