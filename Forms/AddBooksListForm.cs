using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pagino_Teka.Models;
using Pagino_Teka;

namespace Pagino_Teka
{
    public partial class AuthorBooksListForm : Form
    {
        public Book SelectedBook { get; private set; }

        private List<Book> _books;

        public AuthorBooksListForm(List<Book> books)
        {
            InitializeComponent();
            _books = books;
            LoadBooks();
        }

        private void LoadBooks()
        {
            dataGridViewBooks.Rows.Clear();
            foreach (var book in _books)
            {
                dataGridViewBooks.Rows.Add(book.Id, book.Title, book.SeriesName, book.PublisherName, book.Year);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać książkę z listy.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = (int)dataGridViewBooks.SelectedRows[0].Cells["ColumnId"].Value;
            SelectedBook = _books.Find(b => b.Id == bookId);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dataGridViewBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                buttonEdit_Click(sender, e);
        }
    }
}
