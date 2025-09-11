using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pagino_Teka.Forms
{
    public partial class EditBookForm : Form
    {
        private readonly Book _book;
        private readonly BookService _bookService;

        public EditBookForm(Book book, BookService bookService)
        {
            InitializeComponent();
            _book = book;
            _bookService = bookService;
            LoadBookData();
        }

        private void LoadBookData()
        {
            textBoxTitle.Text = _book.Title;
            textBoxDescription.Text = _book.Description;
            textBoxIsbn.Text = _book.Isbn;
            numericUpDownPages.Value = _book.Pages;
            numericUpDownReadTime.Value = _book.ReadTime;
            textBoxPublisher.Text = _book.PublisherName;
            textBoxSeries.Text = _book.SeriesName;
            numericUpDownSeriesNumber.Value = _book.SeriesNumber ?? 0;
            textBoxAuthors.Text = _book.AuthorsText;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _book.Title = textBoxTitle.Text.Trim();
            _book.Description = textBoxDescription.Text.Trim();
            _book.Isbn = textBoxIsbn.Text.Trim();
            _book.Pages = (int)numericUpDownPages.Value;
            _book.ReadTime = (int)numericUpDownReadTime.Value;
            _book.PublisherName = textBoxPublisher.Text.Trim();
            _book.SeriesName = textBoxSeries.Text.Trim();
            _book.SeriesNumber = (int)numericUpDownSeriesNumber.Value;
            _book.AuthorsText = textBoxAuthors.Text.Trim();

            _bookService.UpdateBook(_book, _book.AuthorsText, new List<Genre> { new Genre { Id = _book.GenreId } });

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var confirm = Microsoft.VisualBasic.Interaction.InputBox(
                $"Aby usunąć książkę wpisz jej tytuł:\n\n{_book.Title}",
                "Potwierdź usunięcie",
                ""
            );

            if (confirm == _book.Title)
            {
                _bookService.DeleteBook(_book.Id);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Tytuł nie pasuje. Anulowano usunięcie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
