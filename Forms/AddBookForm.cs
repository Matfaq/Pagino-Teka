using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pagino_Teka.Models;
using Pagino_Teka.Repositories;
using Pagino_Teka.Database;
using Pagino_Teka.Services;
using Pagino_Teka.Theme;

namespace Pagino_Teka
{
    public partial class AddBookForm : Form
    {
        private readonly BookService _bookService;
        private readonly DatabaseService _databaseService;

        public AddBookForm(DatabaseService databaseService)
        {
            InitializeComponent();

            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            _bookService = new BookService(_databaseService);

            // Podpięcie zdarzeń przycisków
            button_AddPublisher.Click += button_AddPublisher_Click;
            button_ZapiszKsiążkę.Click += button_ZapiszKsiążkę_Click;
            button_ZapiszKolejna.Click += button_ZapiszKolejna_Click;
            button_PobierzISBN.Click += button_PobierzISBN_Click;
            button_PobierzZSieci.Click += button_PobierzISBN_Click;
            button_WybierzZDysku.Click += button_WybierzZDysku_Click;
            button_Anuluj.Click += button_Anuluj_Click;

            try { ThemeManager.ApplyTheme(this); } catch { }

            LoadGenres();
            LoadPublishers();
            LoadSeries();
        }

        private void LoadGenres()
        {
            checkedListBox_Gatunki.BeginUpdate();
            checkedListBox_Gatunki.Items.Clear();

            var genres = _bookService.GetGenres();
            foreach (var g in genres)
                checkedListBox_Gatunki.Items.Add(g);

            checkedListBox_Gatunki.DisplayMember = nameof(Genre.Name);
            checkedListBox_Gatunki.ValueMember = nameof(Genre.Id);
            checkedListBox_Gatunki.EndUpdate();
        }

        private void LoadPublishers()
        {
            comboBox_Publisher.SelectedIndexChanged -= ComboBox_Publisher_SelectedIndexChanged;

            var publishers = _bookService.GetAllPublishers();
            comboBox_Publisher.DataSource = null;
            comboBox_Publisher.DataSource = publishers;
            comboBox_Publisher.DisplayMember = nameof(Publisher.Name);
            comboBox_Publisher.ValueMember = nameof(Publisher.Id);
            comboBox_Publisher.SelectedIndex = 0;
            comboBox_Publisher.DropDownStyle = ComboBoxStyle.DropDown;

            comboBox_Publisher.SelectedIndexChanged += ComboBox_Publisher_SelectedIndexChanged;
        }

        private void LoadSeries()
        {
            comboBox_BookSeries.SelectedIndexChanged -= ComboBox_BookSeries_SelectedIndexChanged;

            var series = _bookService.GetAllSeries();
            comboBox_BookSeries.DataSource = null;
            comboBox_BookSeries.DataSource = series;
            comboBox_BookSeries.DisplayMember = nameof(BookSeries.Name);
            comboBox_BookSeries.ValueMember = nameof(BookSeries.Id);
            comboBox_BookSeries.SelectedIndex = -1;
            comboBox_BookSeries.DropDownStyle = ComboBoxStyle.DropDown;

            comboBox_BookSeries.SelectedIndexChanged += ComboBox_BookSeries_SelectedIndexChanged;
        }

        private async void button_PobierzISBN_Click(object sender, EventArgs e)
        {
            string isbn = textBox_Isbn.Text.Trim();
            if (string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("Podaj numer ISBN.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var meta = await _bookService.GetBookByIsbnAsync(isbn);

                textBox_BookTitle.Text = meta.Title;
                textBox_Autorzy.Text = string.Join(", ", meta.Authors ?? Enumerable.Empty<string>());
                textBox_Pages.Text = meta.Pages > 0 ? meta.Pages.ToString() : string.Empty;
                textBox_ReadTime.Text = meta.EstimatedReadTime > 0 ? Math.Round(meta.EstimatedReadTime).ToString() : string.Empty;
                text_BookNote.Text = meta.Description ?? string.Empty;
                comboBox_BookSeries.Text = meta.Series ?? string.Empty;
                textBox_Tome.Text = meta.Tome ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(meta.Publisher))
                {
                    var existing = comboBox_Publisher.Items.Cast<Publisher>()
                        .FirstOrDefault(x => string.Equals(x.Name, meta.Publisher, StringComparison.OrdinalIgnoreCase));

                    if (existing != null)
                        comboBox_Publisher.SelectedItem = existing;
                    else
                    {
                        var temp = new Publisher { Id = 0, Name = meta.Publisher };
                        (comboBox_Publisher.DataSource as System.Collections.IList)?.Add(temp);
                        comboBox_Publisher.SelectedItem = temp;
                    }
                }

                if (!string.IsNullOrWhiteSpace(meta.CoverUrl))
                {
                    pictureBox_Okladka.ImageLocation = meta.CoverUrl;
                    pictureBox_Okladka.SizeMode = PictureBoxSizeMode.Zoom;
                }

                if (meta.Genres != null)
                {
                    for (int i = 0; i < checkedListBox_Gatunki.Items.Count; i++)
                    {
                        if (checkedListBox_Gatunki.Items[i] is Genre g)
                        {
                            bool match = meta.Genres.Any(mg => string.Equals(mg, g.Name, StringComparison.OrdinalIgnoreCase));
                            checkedListBox_Gatunki.SetItemChecked(i, match);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy pobieraniu danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_WybierzZDysku_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pliki graficzne (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Wszystkie pliki (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Okladka.ImageLocation = openFileDialog1.FileName;
                pictureBox_Okladka.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button_AddPublisher_Click(object sender, EventArgs e)
        {
            string name = comboBox_Publisher.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Podaj nazwę wydawcy.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = _bookService.AddPublisherIfNotExists(name);
                LoadPublishers();
                var selected = comboBox_Publisher.Items.Cast<Publisher>().FirstOrDefault(x => x.Id == id);
                if (selected != null)
                    comboBox_Publisher.SelectedItem = selected;
                else
                    comboBox_Publisher.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy dodawaniu wydawcy: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Anuluj_Click(object sender, EventArgs e)
        {
            pictureBox_Okladka?.Image?.Dispose();
            pictureBox_Okladka.Image = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private string GetPublicationType()
        {
            if (radioButton_Książka.Checked) return "druk";
            if (radioButton_Ebook.Checked) return "ebook";
            if (radioButton_Audiobook.Checked) return "audiobook";
            return string.Empty;
        }

        private string GetAdaptationType()
        {
            if (radioButton_NaPodFil.Checked) return "film";
            if (radioButton_NaPodGry.Checked) return "gra";
            return string.Empty;
        }

        private bool SaveBookToDatabase()
        {
            try
            {
                string title = textBox_BookTitle.Text.Trim();
                string authorsText = textBox_Autorzy.Text.Trim();
                string isbn = textBox_Isbn.Text.Trim();
                var selectedGenres = checkedListBox_Gatunki.CheckedItems.Cast<Genre>().ToList();
                int pages = int.TryParse(textBox_Pages.Text, out var p) ? p : 0;
                int readTime = int.TryParse(textBox_ReadTime.Text, out var rt) ? rt : 0;
                int? tome = int.TryParse(textBox_Tome.Text, out var tVal) ? (int?)tVal : null;
                string seriesName = comboBox_BookSeries.Text?.Trim() ?? string.Empty;
                string publishedKind = GetPublicationType();
                string adaptation = GetAdaptationType();
                string publisherName = (comboBox_Publisher.SelectedItem as Publisher)?.Name ?? comboBox_Publisher.Text?.Trim() ?? string.Empty;
                string description = text_BookNote.Text?.Trim() ?? string.Empty;

                string imagePath = string.Empty;
                if (!string.IsNullOrWhiteSpace(pictureBox_Okladka.ImageLocation))
                {
                    string destFolder = Path.Combine(_databaseService.GetAppFolderPath(), "Images", "book_covers");
                    Directory.CreateDirectory(destFolder);

                    string fileName = pictureBox_Okladka.ImageLocation.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                        ? $"{Guid.NewGuid()}.jpg"
                        : $"{Guid.NewGuid()}_{Path.GetFileName(pictureBox_Okladka.ImageLocation)}";

                    string destPath = Path.Combine(destFolder, fileName);

                    if (pictureBox_Okladka.ImageLocation.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        using var client = new System.Net.Http.HttpClient();
                        var bytes = client.GetByteArrayAsync(pictureBox_Okladka.ImageLocation).Result;
                        File.WriteAllBytes(destPath, bytes);
                    }
                    else if (File.Exists(pictureBox_Okladka.ImageLocation))
                    {
                        File.Copy(pictureBox_Okladka.ImageLocation, destPath, overwrite: true);
                    }

                    imagePath = destPath;
                }

                _bookService.SaveBook(
                    title, authorsText, isbn, selectedGenres, pages, readTime,
                    seriesName, tome, publishedKind, adaptation,
                    publisherName, imagePath, description
                );

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy zapisie książki:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button_ZapiszKsiążkę_Click(object sender, EventArgs e)
        {
            if (SaveBookToDatabase())
            {
                MessageBox.Show("Książka została zapisana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button_ZapiszKolejna_Click(object sender, EventArgs e)
        {
            if (!SaveBookToDatabase()) return;

            MessageBox.Show(
                "Książka została zapisana. Formularz został zresetowany do dodania kolejnej.",
                "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            ClearForm();
            LoadGenres();
            LoadPublishers();
            LoadSeries();
        }

        private void ClearForm()
        {
            textBox_BookTitle.Clear();
            textBox_Autorzy.Clear();
            textBox_Isbn.Clear();
            textBox_Pages.Clear();
            textBox_ReadTime.Clear();
            textBox_Tome.Clear();
            text_BookNote.Clear();
            pictureBox_Okladka.Image = null;

            radioButton_Książka.Checked = true;
            radioButton_Ebook.Checked = false;
            radioButton_Audiobook.Checked = false;
            radioButton_NaPodFil.Checked = false;
            radioButton_NaPodGry.Checked = false;

            comboBox_Publisher.SelectedIndex = 0;
            comboBox_BookSeries.SelectedIndex = -1;

            for (int i = 0; i < checkedListBox_Gatunki.Items.Count; i++)
                checkedListBox_Gatunki.SetItemChecked(i, false);
        }

        private void ComboBox_Publisher_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ComboBox_BookSeries_SelectedIndexChanged(object sender, EventArgs e) { }

        
    }
}
