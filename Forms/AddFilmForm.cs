using System;
using System.Windows.Forms;
using Pagino_Teka.Services;
using Pagino_Teka.Database;

namespace Pagino_Teka
{
    public partial class AddFilmForm : Form
    {
        // Przechowuje referencję do singletona DatabaseService,
        // dzięki czemu możemy korzystać z bazy danych.
        private readonly DatabaseService _databaseService;

        // FilmRepository będzie służyć do pobierania danych o gatunkach z bazy.
        private readonly FilmRepository _filmRepository;

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
                // Ustawiamy wybrany plik jako obraz w PictureBox i dopasowujemy rozmiar.
                pictureBox_Plakat.ImageLocation = openFileDialog.FileName;
                pictureBox_Plakat.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // Obługa kliknięcia przycisku "Zapisz film".
        private void button_ZapiszFilm_Click(object sender, EventArgs e)
        {
            string title = textBox_FilmTitle.Text.Trim();
            // Sprawdzamy, czy pole tytułu nie jest puste.
            if (string.IsNullOrWhiteSpace(textBox_FilmTitle.Text))
            {
                MessageBox.Show("Tytuł filmu nie może być pusty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string director = textBox_FilmDirector.Text.Trim();
            string screenwriter = textBox_FilmScreenwriter.Text.Trim();
            string year = textBox_FilmYear.Text.Trim();
            string run_time = textBox_RunTime.Text.Trim();
            string FilmGenre = string.Join(", ", checkedListBox_FGatunki.CheckedItems);
            string language = textBox_Language.Text.Trim();
            string based_on = groupBox_NaPodstawie.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text ?? string.Empty;
            string poster = pictureBox_Plakat.ImageLocation ?? string.Empty;
            string description = textBox_description.Text.Trim();
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

        
    }
}
