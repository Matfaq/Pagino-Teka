using Pagino_Teka.Forms;
using Pagino_Teka.Forms.Dialogs;
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

        public MainForm()
        {
            InitializeComponent();
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
                var dbService = DatabaseService.Instance;
                var bookService = new BookService(dbService);

                // Liczba książek i autorów
                int booksCount = Convert.ToInt32(dbService.ExecuteScalar("SELECT COUNT(*) FROM books"));
                int authorsCount = Convert.ToInt32(dbService.ExecuteScalar("SELECT COUNT(*) FROM authors"));

                // Liczba zapisanych okładek
                string coversFolder = Path.Combine(dbService.GetAppFolderPath(), "Images", "book_covers");
                int coversCount = Directory.Exists(coversFolder) ? Directory.GetFiles(coversFolder).Length : 0;

                // Pobranie wszystkich serii i książek przypisanych do nich
                var allSeries = bookService.GetAllSeries();
                var cycleInfo = new StringBuilder();
                cycleInfo.AppendLine("\n📚 Książki w cyklach:");

                bool hasAny = false;

                foreach (var series in allSeries)
                {
                    // Pobieramy książki w tej serii
                    DataTable booksTable = dbService.ExecuteQuery(
                        "SELECT title, tome FROM books WHERE book_series_id = @seriesId ORDER BY tome;",
                        new Microsoft.Data.Sqlite.SqliteParameter("@seriesId", series.Id)
                    );

                    if (booksTable.Rows.Count == 0)
                        continue;

                    hasAny = true;

                    // Poprawna odmiana słowa "książka"
                    string bookWord = booksTable.Rows.Count == 1 ? "książka" :
                                      (booksTable.Rows.Count >= 2 && booksTable.Rows.Count <= 4) ? "książki" : "książek";

                    cycleInfo.AppendLine($"\n→ Cykl: {series.Name} ({booksTable.Rows.Count} {bookWord})");

                    foreach (DataRow row in booksTable.Rows)
                    {
                        string title = row["title"].ToString() ?? string.Empty;
                        string tome = row["tome"]?.ToString() ?? "?";
                        cycleInfo.AppendLine($"   #{tome}: {title}");
                    }
                }

                if (!hasAny)
                    cycleInfo.AppendLine("Brak książek przypisanych do cykli.");

                // Tworzymy komunikat
                string message = $"Liczba książek: {booksCount}\n" +
                                 $"Liczba autorów: {authorsCount}\n" +
                                 $"Liczba zapisanych okładek: {coversCount}" +
                                 cycleInfo.ToString();

                MessageBox.Show(message, "Status bazy", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void poAutorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dlg = new SearchAuthorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string author = dlg.AuthorName;

                // Wyszukanie książek autora w BookService
                var books = BookService.Instance.SearchByAuthor(author);

                if (books == null || books.Count == 0)
                {
                    MessageBox.Show($"Nie znaleziono książek autora: {author}", "Brak wyników", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Wyświetlenie listy książek autora
                using var listForm = new AuthorBooksListForm(books);
                if (listForm.ShowDialog() == DialogResult.OK)
                {
                    // Pobranie wybranej książki do edycji/usunięcia
                    var selectedBook = listForm.SelectedBook;
                    if (selectedBook != null)
                    {
                        using var editForm = new EditBookForm(selectedBook);
                        editForm.ShowDialog();

                        // Po zamknięciu editForm można odświeżyć listę/menu, jeśli potrzebne
                    }
                }
            }
        }

    }
}
