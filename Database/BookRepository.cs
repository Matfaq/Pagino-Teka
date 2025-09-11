using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pagino_Teka.Database
{
    public class BookRepository
    {
        private readonly DatabaseService _databaseService;

        public BookRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<Genre> GetAllGenres()
        {
            var genres = new List<Genre>();
            DataTable table = _databaseService.ExecuteQuery("SELECT id, name FROM BookGenres ORDER BY name;");
            foreach (DataRow row in table.Rows)
            {
                genres.Add(new Genre
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString() ?? string.Empty
                });
            }
            return genres;
        }

        public int AddBook(Book book, int mainAuthorId, int genreId, int? seriesId, int? tome, int publisherId)
        {
            string sql = @"
INSERT INTO books
(title, author_id, isbn, genre_id, pages, read_time, book_series_id, tome, published_kind, adaptation, publisher_id, image, description)
VALUES
(@title, @auth_id, @isbn, @genre_id, @pages, @read_time, @series_id, @tome, '', '', @publisher_id, @image, @description);
";
            _databaseService.ExecuteNonQuery(sql,
                new SqliteParameter("@title", book.Title),
                new SqliteParameter("@auth_id", mainAuthorId),
                new SqliteParameter("@isbn", book.Isbn),
                new SqliteParameter("@genre_id", genreId),
                new SqliteParameter("@pages", book.Pages),
                new SqliteParameter("@read_time", book.ReadTime),
                new SqliteParameter("@series_id", seriesId ?? (object)DBNull.Value),
                new SqliteParameter("@tome", tome ?? (object)DBNull.Value),
                new SqliteParameter("@publisher_id", publisherId),
                new SqliteParameter("@image", book.ImagePath ?? string.Empty),
                new SqliteParameter("@description", book.Description ?? string.Empty)
            );

            object idObj = _databaseService.ExecuteScalar("SELECT last_insert_rowid();");
            return Convert.ToInt32(idObj);
        }

        public void AddBookAuthor(int bookId, int authorId)
        {
            _databaseService.ExecuteNonQuery(
                "INSERT OR IGNORE INTO BookAuthors (book_id, author_id) VALUES (@book_id, @auth_id);",
                new SqliteParameter("@book_id", bookId),
                new SqliteParameter("@auth_id", authorId)
            );
        }

        public void UpdateBook(Book book)
        {
            string sql = @"
UPDATE books
SET title=@title, author_id=@auth_id, isbn=@isbn, genre_id=@genre_id,
    pages=@pages, read_time=@read_time, book_series_id=@series_id, tome=@tome,
    publisher_id=@publisher_id, image=@image, description=@description
WHERE id=@id;
";
            _databaseService.ExecuteNonQuery(sql,
                new SqliteParameter("@id", book.Id),
                new SqliteParameter("@title", book.Title),
                new SqliteParameter("@auth_id", book.AuthorId),
                new SqliteParameter("@isbn", book.Isbn),
                new SqliteParameter("@genre_id", book.GenreId),
                new SqliteParameter("@pages", book.Pages),
                new SqliteParameter("@read_time", book.ReadTime),
                new SqliteParameter("@series_id", book.SeriesId ?? (object)DBNull.Value),
                new SqliteParameter("@tome", book.Tome ?? (object)DBNull.Value),
                new SqliteParameter("@publisher_id", book.PublisherId),
                new SqliteParameter("@image", book.ImagePath ?? string.Empty),
                new SqliteParameter("@description", book.Description ?? string.Empty)
            );
        }

        public void DeleteBook(int bookId)
        {
            ClearBookAuthors(bookId);
            _databaseService.ExecuteNonQuery(
                "DELETE FROM books WHERE id=@id;",
                new SqliteParameter("@id", bookId)
            );
        }

        public void ClearBookAuthors(int bookId)
        {
            _databaseService.ExecuteNonQuery(
                "DELETE FROM BookAuthors WHERE book_id=@book_id;",
                new SqliteParameter("@book_id", bookId)
            );
        }

        public Book? GetBookById(int id)
        {
            DataTable table = _databaseService.ExecuteQuery("SELECT * FROM books WHERE id=@id;",
                new SqliteParameter("@id", id));
            if (table.Rows.Count == 0) return null;

            var row = table.Rows[0];
            return new Book
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"].ToString() ?? string.Empty,
                Isbn = row["isbn"].ToString() ?? string.Empty,
                Pages = row["pages"] != DBNull.Value ? Convert.ToInt32(row["pages"]) : 0,
                ReadTime = row["read_time"] != DBNull.Value ? Convert.ToInt32(row["read_time"]) : 0,
                Description = row["description"].ToString() ?? string.Empty,
                ImagePath = row["image"].ToString() ?? string.Empty,
                AuthorId = row["author_id"] != DBNull.Value ? Convert.ToInt32(row["author_id"]) : 0,
                GenreId = row["genre_id"] != DBNull.Value ? Convert.ToInt32(row["genre_id"]) : 0,
                PublisherId = row["publisher_id"] != DBNull.Value ? Convert.ToInt32(row["publisher_id"]) : 0,
                SeriesId = row["book_series_id"] != DBNull.Value ? Convert.ToInt32(row["book_series_id"]) : null,
                Tome = row["tome"] != DBNull.Value ? Convert.ToInt32(row["tome"]) : null
            };
        }
    }
}
