using System;
using System.Windows.Forms;
using Pagino_Teka.Services;
using Pagino_Teka.Database;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Pagino_Teka.Models; // Dodaj tę dyrektywę using na górze pliku

namespace Pagino_Teka
{
    public partial class AddFilmForm : Form
    {
        // Przechowuje referencję do singletona DatabaseService,
        // dzięki czemu możemy korzystać z bazy danych.
        private readonly DatabaseService _databaseService;

        // FilmRepository będzie służyć do pobierania danych o gatunkach z bazy.
        private readonly FilmRepository _filmRepository;

        // Dodaj pole TranslateService do klasy AddFilmForm:
        private readonly TranslateService _translateService = new TranslateService();

        // Konstruktor formularza wymaga przekazania DatabaseService,
        // co zapewnia dostęp do bazy danych.
        public AddFilmForm(DatabaseService databaseService)
        {
            InitializeComponent();

            Theme.ThemeManager.ApplyTheme(this);

            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));

            // Inicjalizacja repozytorium filmów z podanym serwisem bazy danych.
            _filmRepository = new FilmRepository(_databaseService);

            // Wczytanie i załadowanie gatunków do CheckedListBox po uruchomieniu formularza.
            LoadFilmGenres();
        }

        /// <summary>
        /// Metoda ładuje gatunki filmów z bazy i dodaje je do CheckedListBox.
        /// </summary>
        private void LoadFilmGenres()
        {
            // Najpierw wyczyść wszystkie elementy w CheckedListBox,
            // żeby uniknąć duplikatów podczas ponownego wywołania.
            checkedListBox_FGatunki.Items.Clear();

            // Pobieramy listę gatunków z bazy przez FilmRepository.
            var genres = _filmRepository.GetAllGenres();

            // Iterujemy po wszystkich gatunkach i dodajemy je do kontrolki.
            foreach (var genre in genres)
            {
                checkedListBox_FGatunki.Items.Add(genre);
            }
        }

        /// <summary>
        /// Obsługa kliknięcia przycisku "Wybierz plakat".
        /// Otwiera dialog wyboru pliku graficznego i ustawia obraz w PictureBox.
        /// </summary>
        private void button_WybierzPlakat_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Wybierz plakat filmu",
                Filter = "Pliki graficzne (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Wszystkie pliki (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Plakat.ImageLocation = openFileDialog.FileName;
                pictureBox_Plakat.SizeMode = PictureBoxSizeMode.Zoom; // Dostosowanie do rozmiaru kontrolki
            }
        }

        // Obługa kliknięcia przycisku "Zapisz film".
        private void button_ZapiszFilm_Click(object sender, EventArgs e)
        {
            string title = textBox_FilmTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Tytuł filmu nie może być pusty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SPRAWDZENIE UNIKALNOŚCI TYTUŁU
            if (!FilmService.Instance.IsTitleUnique(title))
            {
                MessageBox.Show("Film o podanym tytule już istnieje w bazie!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string director = textBox_FilmDirector.Text.Trim();
            string year = textBox_FilmYear.Text.Trim();
            string run_time = textBox_RunTime.Text.Trim();
            string language = textBox_Language.Text.Trim();
            string based_on = groupBox_NaPodstawie.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text ?? string.Empty;
            string description = textBox_description.Text.Trim();

            int directorId = FilmService.Instance.GetOrAddPersonId(director, "Director");

            // Obsługa wielu scenarzystów
            var screenwriterNames = textBox_FilmScreenwriter.Text.Split(',')
                .Select(n => n.Trim())
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .ToList();
            var screenwriterIds = new List<int>();
            foreach (var name in screenwriterNames)
            {
                screenwriterIds.Add(FilmService.Instance.GetOrAddPersonId(name, "Screenwriter"));
            }

            var genreIds = new List<int>();
            foreach (var item in checkedListBox_FGatunki.CheckedItems)
            {
                if (item is Genre genre)
                    genreIds.Add(genre.Id);
            }

            // WALIDACJA: przynajmniej jeden gatunek musi być wybrany
            if (genreIds.Count == 0)
            {
                MessageBox.Show("Musisz wybrać przynajmniej jeden gatunek filmu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int? yearInt = int.TryParse(year, out var y) ? y : (int?)null;
            int? durationInt = int.TryParse(run_time, out var d) ? d : (int?)null;

            // Zapis plakatu do folderu aplikacji (jak okładka książki)
            string poster = SavePosterImageIfNeeded();

            var film = new Film
            {
                Title = title,
                DirectorId = directorId,
                ScreenwriterIds = screenwriterIds,
                ScreenwriterNames = screenwriterNames,
                Year = yearInt,
                Duration = durationInt,
                Language = language,
                Image = poster,
                Description = description,
                GenreIds = genreIds,
                BasedOn = based_on
            };

            _filmRepository.Add(film);

            MessageBox.Show("Film został zapisany w bazie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Obsługa kliknięcia przycisku "Anuluj".
        /// Usuwa załadowany plakat i zamyka formularz.
        /// </summary>
        private void button_Anuluj_Click(object sender, EventArgs e)
        {
            // Jeśli obraz plakatu jest załadowany, zwalniamy zasoby.
            if (pictureBox_Plakat.Image != null)
            {
                pictureBox_Plakat.Image.Dispose();
                pictureBox_Plakat.Image = null;
            }

            // Zamykamy formularz.
            this.Close();
        }

        private async void button_PobierzDaneOmdb_Click(object sender, EventArgs e)
        {
            string titlePl = textBox_FilmTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(titlePl))
            {
                MessageBox.Show("Podaj tytuł filmu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Tłumaczenie tytułu na angielski przez TranslateService
            string titleEn = await _translateService.TranslateAsync(titlePl, "pl", "en");

            // 2. Pobranie klucza API z pliku user_settings.json
            string apiKey = GetOmdbApiKey();
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("Brak klucza OMDB API. Ustaw go w konfiguracji!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string url = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(titleEn)}&apikey={apiKey}&plot=full";
            using var client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var omdb = JsonSerializer.Deserialize<OmdbFilmDto>(response);

            if (omdb == null || omdb.Response != "True")
            {
                MessageBox.Show("Nie znaleziono filmu w OMDB.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 3. Tłumaczenie pobranych danych na polski przez TranslateService
            textBox_FilmTitle.Text = await _translateService.TranslateAsync(omdb.Title ?? "", "en", "pl");
            textBox_FilmDirector.Text = await _translateService.TranslateAsync(omdb.Director ?? "", "en", "pl");
            textBox_FilmScreenwriter.Text = await _translateService.TranslateAsync(omdb.Writer ?? "", "en", "pl");
            textBox_FilmYear.Text = omdb.Year ?? "";
            textBox_RunTime.Text = omdb.Runtime?.Replace(" min", "") ?? "";
            textBox_Language.Text = await _translateService.TranslateAsync(omdb.Language ?? "", "en", "pl");
            textBox_description.Text = await _translateService.TranslateAsync(omdb.Plot ?? "", "en", "pl");
            pictureBox_Plakat.ImageLocation = omdb.Poster ?? "";
            pictureBox_Plakat.SizeMode = PictureBoxSizeMode.Zoom; // Dostosowanie do rozmiaru kontrolki

            // 4. Gatunki: odznacz wszystko, zaznacz pasujące
            for (int i = 0; i < checkedListBox_FGatunki.Items.Count; i++)
            {
                var genre = checkedListBox_FGatunki.Items[i].ToString();
                checkedListBox_FGatunki.SetItemChecked(i, omdb.Genre?.Contains(genre) == true);
            }

            // 5. Sprawdzenie reżysera i scenarzysty w bazie, dodanie jeśli nie istnieje
            int directorId = FilmService.Instance.GetOrAddPersonId(textBox_FilmDirector.Text.Trim(), "Director");
            int screenwriterId = FilmService.Instance.GetOrAddPersonId(textBox_FilmScreenwriter.Text.Trim(), "Screenwriter");
            // Przypisz te ID do obiektu Film, jeśli jest tworzony
        }

        // DTO do OMDB
        public class OmdbFilmDto
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Writer { get; set; }
            public string Language { get; set; }
            public string Plot { get; set; }
            public string Poster { get; set; }
            public string Response { get; set; }
        }

        private void ShowScrollableError(string title, string message)
        {
            var form = new Form
            {
                Text = title,
                Width = 600,
                Height = 400,
                StartPosition = FormStartPosition.CenterParent
            };

            var textBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Text = message,
                WordWrap = false
            };

            form.Controls.Add(textBox);
            form.ShowDialog(this);
        }

        private string GetOmdbApiKey()
        {
            string appFolder = _databaseService.GetAppFolderPath();
            string settingsPath = Path.Combine(appFolder, "user_settings.json");

            if (!File.Exists(settingsPath))
                return string.Empty;

            try
            {
                var json = File.ReadAllText(settingsPath);
                var userSettings = JsonSerializer.Deserialize<UserSettings>(json);
                return userSettings?.OmdbApiKey ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private class UserSettings
        {
            public bool UseOmdbApi { get; set; }
            public string OmdbApiKey { get; set; }
        }

        // Dodaj metodę do klasy AddFilmForm:
        private string SavePosterImageIfNeeded()
        {
            if (string.IsNullOrWhiteSpace(pictureBox_Plakat.ImageLocation))
                return string.Empty;

            string destFolder = Path.Combine(_databaseService.GetAppFolderPath(), "Images", "film_posters");
            Directory.CreateDirectory(destFolder);

            string fileName = pictureBox_Plakat.ImageLocation.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                ? $"{Guid.NewGuid()}.jpg"
                : $"{Guid.NewGuid()}_{Path.GetFileName(pictureBox_Plakat.ImageLocation)}";

            string destPath = Path.Combine(destFolder, fileName);

            if (pictureBox_Plakat.ImageLocation.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                using var client = new System.Net.Http.HttpClient();
                var bytes = client.GetByteArrayAsync(pictureBox_Plakat.ImageLocation).Result;
                File.WriteAllBytes(destPath, bytes);
            }
            else if (File.Exists(pictureBox_Plakat.ImageLocation))
            {
                File.Copy(pictureBox_Plakat.ImageLocation, destPath, overwrite: true);
            }

            return destPath;
        }
    }
}
