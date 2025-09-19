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
                // Ustaw domyślne wartości
                checkBox_UseGoogleApi.Checked = false;
                textBox_GoogleApiKey.Text = string.Empty;
                radioButton_Light.Checked = true;

                // Odczyt user_settings.json (jeśli istnieje)
                if (File.Exists(SettingsJsonPath))
                {
                    var json = File.ReadAllText(SettingsJsonPath);
                    var s = System.Text.Json.JsonSerializer.Deserialize<UserSettings>(json) ?? new UserSettings();
                    checkBox_UseGoogleApi.Checked = s.UseGoogleApi;
                    textBox_GoogleApiKey.Text = s.GoogleApiKey ?? string.Empty;
                }

                // Odczyt theme.txt
                if (File.Exists(ThemePath))
                {
                    var theme = (File.ReadAllText(ThemePath) ?? "Light").Trim();
                    if (theme.Equals("Dark", StringComparison.OrdinalIgnoreCase))
                        radioButton_Dark.Checked = true;
                    else
                        radioButton_Light.Checked = true;
                }

                UpdateApiKeyTextboxEnabled();
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

        private void checkBox_UseGoogleApi_CheckedChanged(object sender, EventArgs e)
        {
            UpdateApiKeyTextboxEnabled();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(_appDataPath);

                // Zapis user_settings.json
                var s = new UserSettings
                {
                    UseGoogleApi = checkBox_UseGoogleApi.Checked,
                    GoogleApiKey = textBox_GoogleApiKey.Text?.Trim() ?? string.Empty
                };
                var json = System.Text.Json.JsonSerializer.Serialize(s, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsJsonPath, json);

                // Zapis theme.txt
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

        private void button_TmdbKeyLink_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.themoviedb.org/settings/api"); // panel do wygenerowania klucza
        }

        private void button_DocsTmdbKey_Click(object sender, EventArgs e)
        {
            OpenUrl("https://developer.themoviedb.org/docs/getting-started"); // dokumentacja API
        }
    }
}
