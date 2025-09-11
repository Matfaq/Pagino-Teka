using System;
using System.Linq;
using System.Windows.Forms;
using Pagino_Teka.Models;
using Pagino_Teka.Services;

namespace Pagino_Teka
{
    public partial class EditBookForm : Form
    {
        private readonly Book book;
        private readonly BookService bookService;

        public EditBookForm(Book book, BookService bookService)
        {
            InitializeComponent();
            this.book = book ?? throw new ArgumentNullException(nameof(book));
            this.bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            LoadPublishers();
            LoadSeries();
            LoadGenres();
            PopulateForm();
        }

        private void LoadPublishers()
        {
            var publishers = bookService.PublisherRepository.GetAll();
            comboBox_Publisher.DataSource = publishers;
            comboBox_Publisher.DisplayMember = "Name";
            comboBox_Publisher.ValueMember = "Id";
        }

        private void LoadSeries()
        {
            var seriesList = bookService.BookSeriesRepository.GetAll();
            comboBox_BookSeries.DataSource = seriesList;
            comboBox_BookSeries.DisplayMember = "Name";
            comboBox_BookSeries.ValueMember = "Id";
        }

        private void LoadGenres()
        {
            var genres = bookService.GenreRepository.GetAll();
            checkedListBox_Gatunki.Items.Clear();
            foreach (var g in genres)
                checkedListBox_Gatunki.Items.Add(g, book.Genres.Any(bg => bg.Id == g.Id));
        }

        private void PopulateForm()
        {
            textBox_Title.Text = book.Title;
            comboBox_Publisher.SelectedValue = book.Publisher?.Id ?? -1;
            comboBox_BookSeries.SelectedValue = book.Series?.Id ?? -1;
            numericUpDown_SeriesNumber.Value = book.SeriesNumber;

            radioButton_Hardcover.Checked = book.EditionType == EditionType.Hardcover;
            radioButton_Paperback.Checked = book.EditionType == EditionType.Paperback;

            textBox_Notes.Text = book.Notes;

            // Zaznacz gatunki
            for (int i = 0; i < checkedListBox_Gatunki.Items.Count; i++)
            {
                var genre = (Genre)checkedListBox_Gatunki.Items[i];
                checkedListBox_Gatunki.SetItemChecked(i, book.Genres.Any(g => g.Id == genre.Id));
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            book.Title = textBox_Title.Text;
            book.Publisher = (Publisher)comboBox_Publisher.SelectedItem;
            book.Series = (BookSeries)comboBox_BookSeries.SelectedItem;
            book.SeriesNumber = (int)numericUpDown_SeriesNumber.Value;
            book.EditionType = radioButton_Hardcover.Checked ? EditionType.Hardcover : EditionType.Paperback;
            book.Notes = textBox_Notes.Text;

            // Gatunki
            book.Genres.Clear();
            foreach (var item in checkedListBox_Gatunki.CheckedItems)
                book.Genres.Add((Genre)item);

            bookService.UpdateBook(book);
            MessageBox.Show("Książka została zaktualizowana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"Czy na pewno chcesz usunąć książkę '{book.Title}'?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                bookService.DeleteBook(book.Id);
                this.Close();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
