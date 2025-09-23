using Pagino_Teka.Forms;
using Pagino_Teka.Services;
using Pagino_Teka;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pagino_Teka
{
    public partial class MainForm : Form
    {
        private readonly string _appFolder;
        private readonly string _themeFile;

        private SplitContainer splitContainer;
        private FlowLayoutPanel booksPanel;
        private FlowLayoutPanel filmsPanel;

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Tryb pełnoekranowy
            InitializePanels();
            Load += MainForm_Load;

            // Ścieżka do katalogu aplikacji w profilu użytkownika
            _appFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Pagino-Teka"
            );

            // Plik przechowujący wybrany motyw
            _themeFile = Path.Combine(_appFolder, "theme.txt");
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            try
            {
                // 🔹 Sprawdź czy istnieje plik ustawień (user_settings.json)
                string settingsFile = Path.Combine(_appFolder, "user_settings.json");
                if (!File.Exists(settingsFile))
                {
                    using var setupForm = new SetupForm(_appFolder);
                    var result = setupForm.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        Application.Exit();
                        return;
                    }
                }

                // 🔹 Inicjalizacja serwisu bazy danych (katalogi + baza + połączenie)
                DatabaseService.Instance.Initialize();

                // 🔹 Wczytanie preferencji motywu
                LoadThemePreference();
                LoadLibraryPanels(); // Dodaj to tutaj
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas inicjalizacji aplikacji:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void DodajKsiążkęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var addBookForm = new AddBookForm(DatabaseService.Instance);
            if (addBookForm.ShowDialog() == DialogResult.OK)
            {
                // Opcjonalnie: odśwież listę książek
            }
        }

        private void dodajFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var addFilmForm = new AddFilmForm(DatabaseService.Instance);
            if (addFilmForm.ShowDialog() == DialogResult.OK)
            {
                // Opcjonalnie: odśwież listę filmów
            }
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void jasnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Theme.ThemeManager.SetTheme(Theme.Themes.Light);
            Theme.ThemeManager.ApplyTheme(this);
            SaveThemePreference("Light");
        }

        private void ciemnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Theme.ThemeManager.SetTheme(Theme.Themes.Dark);
            Theme.ThemeManager.ApplyTheme(this);
            SaveThemePreference("Dark");
        }

        // 🔹 Zapis preferencji do pliku
        private void SaveThemePreference(string themeName)
        {
            try
            {
                if (!Directory.Exists(_appFolder))
                    Directory.CreateDirectory(_appFolder);

                File.WriteAllText(_themeFile, themeName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się zapisać motywu:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 🔹 Wczytanie preferencji z pliku przy starcie
        private void LoadThemePreference()
        {
            try
            {
                if (File.Exists(_themeFile))
                {
                    string themeName = File.ReadAllText(_themeFile).Trim();
                    if (themeName.Equals("Dark", StringComparison.OrdinalIgnoreCase))
                    {
                        Theme.ThemeManager.SetTheme(Theme.Themes.Dark);
                    }
                    else
                    {
                        Theme.ThemeManager.SetTheme(Theme.Themes.Light);
                    }
                }
                else
                {
                    // Domyślnie ustaw Light, jeśli plik nie istnieje
                    Theme.ThemeManager.SetTheme(Theme.Themes.Light);
                }

                Theme.ThemeManager.ApplyTheme(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się wczytać motywu:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 🔹 Obsługa kliknięcia w Status w menu
        /// Wyświetla okno z liczbą książek, autorów, zapisanych okładek
        /// oraz zestawienie książek w cyklach (grupowane wg serii z licznikiem)
        /// </summary>
        private void statustoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                string message = BuildStatusMessage();
                using (var statusForm = new StatusForm(message))
                {
                    statusForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas pobierania statusu:\n{ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Obsługa wywołania konfiguracji z menu
        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var setupForm = new SetupForm(_appFolder);
            var result = setupForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadThemePreference();
            }
        }

        private void InitializePanels()
        {
            splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical
            };

            booksPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            filmsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            splitContainer.Panel1.Controls.Add(booksPanel);
            splitContainer.Panel2.Controls.Add(filmsPanel);
            this.Controls.Add(splitContainer);

            // Ustawienie początkowego podziału 50/50
            splitContainer.SplitterDistance = this.Width / 2;

            // Dynamiczne dostosowanie podziału przy zmianie rozmiaru okna
            this.Resize += (s, e) =>
            {
                splitContainer.SplitterDistance = this.Width / 2;
            };
        }

        private void LoadLibraryPanels()
        {
            booksPanel.Controls.Clear();
            filmsPanel.Controls.Clear();

            var dbService = DatabaseService.Instance;

            // Książki
            var booksTable = dbService.ExecuteQuery("SELECT title, image FROM books ORDER BY title");
            foreach (DataRow row in booksTable.Rows)
            {
                var panel = CreateItemPanel(row["image"]?.ToString(), row["title"]?.ToString());
                booksPanel.Controls.Add(panel);
            }

            // Filmy
            var filmsTable = dbService.ExecuteQuery("SELECT title, poster FROM filmy ORDER BY title");
            foreach (DataRow row in filmsTable.Rows)
            {
                var panel = CreateItemPanel(row["poster"]?.ToString(), row["title"]?.ToString());
                filmsPanel.Controls.Add(panel);
            }
        }

        private Panel CreateItemPanel(string imagePath, string title)
        {
            var itemPanel = new Panel
            {
                Width = 120,
                Height = 180,
                Margin = new Padding(8)
            };

            var picture = new PictureBox
            {
                Width = 100,
                Height = 140,
                SizeMode = PictureBoxSizeMode.Zoom,
                ImageLocation = !string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath) ? imagePath : null
            };

            var label = new Label
            {
                Text = title ?? "",
                Dock = DockStyle.Bottom,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                AutoSize = false,
                Height = 40
            };

            itemPanel.Controls.Add(picture);
            itemPanel.Controls.Add(label);
            label.BringToFront();

            return itemPanel;
        }

        private string BuildStatusMessage()
        {
            var dbService = DatabaseService.Instance;
            var bookService = new BookService(dbService);

            int booksCount = Convert.ToInt32(dbService.ExecuteScalar("SELECT COUNT(*) FROM books"));
            int authorsCount = Convert.ToInt32(dbService.ExecuteScalar("SELECT COUNT(*) FROM authors"));
            string coversFolder = Path.Combine(dbService.GetAppFolderPath(), "Images", "book_covers");
            int coversCount = Directory.Exists(coversFolder) ? Directory.GetFiles(coversFolder).Length : 0;

            int filmsCount = Convert.ToInt32(dbService.ExecuteScalar("SELECT COUNT(*) FROM filmy"));
            int screenwritersCount = Convert.ToInt32(dbService.ExecuteScalar("SELECT COUNT(*) FROM Screenwriters"));
            int directorsCount = Convert.ToInt32(dbService.ExecuteScalar("SELECT COUNT(*) FROM Directors"));
            string postersFolder = Path.Combine(dbService.GetAppFolderPath(), "Images", "film_posters");
            int postersCount = Directory.Exists(postersFolder) ? Directory.GetFiles(postersFolder).Length : 0;

            var allSeries = bookService.GetAllSeries();
            var sb = new StringBuilder();

            sb.AppendLine("📖 Statystyki książek i filmów\n");
            sb.AppendLine($"• Liczba książek: {booksCount}");
            sb.AppendLine($"• Liczba autorów: {authorsCount}");
            sb.AppendLine($"• Liczba zapisanych okładek: {coversCount}\n");

            sb.AppendLine("🎬 Statystyki filmów\n");
            sb.AppendLine($"• Liczba filmów: {filmsCount}");
            sb.AppendLine($"• Liczba scenarzystów: {screenwritersCount}");
            sb.AppendLine($"• Liczba reżyserów: {directorsCount}");
            sb.AppendLine($"• Liczba zapisanych plakatów filmowych: {postersCount}\n");

            sb.AppendLine("────────────────────────────");
            sb.AppendLine("📚 Książki w cyklach:\n");

            bool hasAny = false;
            foreach (var series in allSeries)
            {
                DataTable booksTable = dbService.ExecuteQuery(
                    "SELECT title, tome FROM books WHERE book_series_id = @seriesId ORDER BY tome;",
                    new Microsoft.Data.Sqlite.SqliteParameter("@seriesId", series.Id)
                );

                if (booksTable.Rows.Count == 0)
                    continue;

                hasAny = true;
                string bookWord = booksTable.Rows.Count == 1 ? "książka" :
                                  (booksTable.Rows.Count >= 2 && booksTable.Rows.Count <= 4) ? "książki" : "książek";

                sb.AppendLine($"→ {series.Name} ({booksTable.Rows.Count} {bookWord})");
                foreach (DataRow row in booksTable.Rows)
                {
                    string title = row["title"].ToString() ?? string.Empty;
                    string tome = row["tome"]?.ToString() ?? "?";
                    sb.AppendLine($"   #{tome}: {title}");
                }
                sb.AppendLine();
            }

            if (!hasAny)
                sb.AppendLine("Brak książek przypisanych do cykli.");

            return sb.ToString();
        }
    }
}
