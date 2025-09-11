using Pagino_Teka.Models;
using Pagino_Teka.Database;
using Pagino_Teka;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pagino_Teka.Forms
{
    public partial class AuthorBooksListForm : Form
    {
        private readonly List<Book> _books;
        private readonly BookService _bookService;

        public AuthorBooksListForm(List<Book> books, BookService bookService)
        {
            InitializeComponent();
            _books = books;
            _bookService = bookService;
            LoadBooks();
        }

        private void LoadBooks()
        {
            dataGridViewBooks.Rows.Clear();
            foreach (var book in _books)
            {
                dataGridViewBooks.Rows.Add(book.Id, book.Title, book.Author, book.Publisher, book.Series, book.SeriesNumber);
            }
        }

        private void dataGridViewBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int bookId = (int)dataGridViewBooks.Rows[e.RowIndex].Cells[0].Value;
            var selectedBook = _books.Find(b => b.Id == bookId);

            if (selectedBook != null)
            {
                using (var form = new EditBookForm(selectedBook, _bookService))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadBooks();
                    }
                }
            }
        }
    }
}
