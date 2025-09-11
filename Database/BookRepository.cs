using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Pagino_Teka.Repositories
{
    public class BookRepository
    {
        private readonly DatabaseService _db;

        public BookRepository(DatabaseService db)
        {
            _db = db;
        }

        public void Add(Book book)
        {
            string sql = @"INSERT INTO books (title, isbn, publisher_id, series_id, series_number, edition_type, notes)
                           VALUES (@title, @isbn, @publisher_id, @series_id, @series_number, @edition_type, @notes);
                           SELECT last_insert_rowid();";

            var id = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SQLiteParameter("@title", book.Title),
                new SQLiteParameter("@isbn", book.ISBN),
                new SQLiteParameter("@publisher_id", book.Publisher?.Id),
                new SQLiteParameter("@series_id", book.Series?.Id),
                new SQLiteParameter("@series_number", book.SeriesNumber),
                new SQLiteParameter("@edition_type", (int)book.EditionType),
                new SQLiteParameter("@notes", book.Notes ?? string.Empty)
            ));

            book.Id = id;

            // Zapis gatunków
            foreach (var genre in book.Genres)
            {
                _db.ExecuteNonQuery("INSERT INTO book_genres (book_id, genre_id) VALUES (@book_id, @genre_id)",
                    new SQLiteParameter("@book_id", id),
                    new SQLiteParameter("@genre_id", genre.Id));
            }
        }

        public void Update(Book book)
        {
            string sql = @"UPDATE books SET 
                           title = @title,
                           isbn = @isbn,
                           publisher_id = @publisher_id,
                           series_id = @series_id,
                           series_number = @series_number,
                           edition_type = @edition_type,
                           notes = @notes
                           WHERE id = @id";

            _db.ExecuteNonQuery(sql,
                new SQLiteParameter("@title", book.Title),
                new SQLiteParameter("@isbn", book.ISBN),
                new SQLiteParameter("@publisher_id", book.Publisher?.Id),
                new SQLiteParameter("@series_id", book.Series?.Id),
                new SQLiteParameter("@series_number", book.SeriesNumber),
                new SQLiteParameter("@edition_type", (int)book.EditionType),
                new SQLiteParameter("@notes", book.Notes ?? string.Empty),
                new SQLiteParameter("@id", book.Id)
            );

            // Aktualizacja gatunków
            _db.ExecuteNonQuery("DELETE FROM book_genres WHERE book_id = @book_id",
                new SQLiteParameter("@book_id", book.Id));

            foreach (var genre in book.Genres)
            {
                _db.ExecuteNonQuery("INSERT INTO book_genres (book_id, genre_id) VALUES (@book_id, @genre_id)",
                    new SQLiteParameter("@book_id", book.Id),
                    new SQLiteParameter("@genre_id", genre.Id));
            }
        }

        public void Delete(int id)
        {
            _db.ExecuteNonQuery("DELETE FROM book_genres WHERE book_id = @book_id",
                new SQLiteParameter("@book_id", id));
            _db.ExecuteNonQuery("DELETE FROM books WHERE id = @id",
                new SQLiteParameter("@id", id));
        }

        // NOWA METODA – pobranie ksi¹¿ki po ISBN
        public async Task<Book> GetBookByIsbnAsync(string isbn)
        {
            string sql = "SELECT * FROM books WHERE isbn = @isbn LIMIT 1";
            var dt = await _db.ExecuteQueryAsync(sql, new SQLiteParameter("@isbn", isbn));

            if (dt.Rows.Count == 0)
                return null;

            return MapFromDataRow(dt.Rows[0]);
        }

        private Book MapFromDataRow(DataRow row)
        {
            return new Book
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"].ToString(),
                ISBN = row["isbn"].ToString(),
                Publisher = row["publisher_id"] != DBNull.Value ? new Publisher { Id = Convert.ToInt32(row["publisher_id"]) } : null,
                Series = row["series_id"] != DBNull.Value ? new BookSeries { Id = Convert.ToInt32(row["series_id"]) } : null,
                SeriesNumber = row["series_number"] != DBNull.Value ? Convert.ToInt32(row["series_number"]) : 0,
                EditionType = (EditionType)Convert.ToInt32(row["edition_type"]),
                Notes = row["notes"].ToString()
            };
        }
    }
}
