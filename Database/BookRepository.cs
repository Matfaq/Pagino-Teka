using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pagino_Teka.Repositories
{
    public class BookRepository
    {
        private readonly DatabaseService _db;

        public BookRepository(DatabaseService db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // --- ADD ---
        public void Add(Book book)
        {
            string sql = @"INSERT INTO books (title, isbn, publisher_id, series_id, series_number, tome, year, notes)
                           VALUES (@title, @isbn, @publisher_id, @series_id, @series_number, @tome, @year, @notes);
                           SELECT last_insert_rowid();";

            var id = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqliteParameter("@title", book.Title),
                new SqliteParameter("@isbn", book.Isbn),
                new SqliteParameter("@publisher_id", book.PublisherId > 0 ? (object)book.PublisherId : DBNull.Value),
                new SqliteParameter("@series_id", book.SeriesId > 0 ? (object)book.SeriesId : DBNull.Value),
                new SqliteParameter("@series_number", book.SeriesNumber ?? (object)DBNull.Value),
                new SqliteParameter("@tome", book.Tome ?? (object)DBNull.Value),
                new SqliteParameter("@year", book.Year ?? (object)DBNull.Value),
                new SqliteParameter("@notes", book.Description ?? string.Empty)
            ));

            book.Id = id;

            // 🔹 zapis wielu gatunków
            foreach (var gid in book.GenreIds)
            {
                _db.ExecuteNonQuery("INSERT INTO book_genres (book_id, genre_id) VALUES (@book_id, @genre_id)",
                    new SqliteParameter("@book_id", id),
                    new SqliteParameter("@genre_id", gid));
            }
        }

        // --- UPDATE ---
        public void Update(Book book)
        {
            string sql = @"UPDATE books SET
                           title = @title,
                           isbn = @isbn,
                           publisher_id = @publisher_id,
                           series_id = @series_id,
                           series_number = @series_number,
                           tome = @tome,
                           year = @year,
                           notes = @notes
                           WHERE id = @id";

            _db.ExecuteNonQuery(sql,
                new SqliteParameter("@title", book.Title),
                new SqliteParameter("@isbn", book.Isbn),
                new SqliteParameter("@publisher_id", book.PublisherId > 0 ? (object)book.PublisherId : DBNull.Value),
                new SqliteParameter("@series_id", book.SeriesId > 0 ? (object)book.SeriesId : DBNull.Value),
                new SqliteParameter("@series_number", book.SeriesNumber ?? (object)DBNull.Value),
                new SqliteParameter("@tome", book.Tome ?? (object)DBNull.Value),
                new SqliteParameter("@year", book.Year ?? (object)DBNull.Value),
                new SqliteParameter("@notes", book.Description ?? string.Empty),
                new SqliteParameter("@id", book.Id)
            );

            // 🔹 odświeżenie gatunków
            _db.ExecuteNonQuery("DELETE FROM book_genres WHERE book_id = @book_id",
                new SqliteParameter("@book_id", book.Id));

            foreach (var gid in book.GenreIds)
            {
                _db.ExecuteNonQuery("INSERT INTO book_genres (book_id, genre_id) VALUES (@book_id, @genre_id)",
                    new SqliteParameter("@book_id", book.Id),
                    new SqliteParameter("@genre_id", gid));
            }
        }

        // --- DELETE ---
        public void Delete(int id)
        {
            _db.ExecuteNonQuery("DELETE FROM book_genres WHERE book_id = @book_id",
                new SqliteParameter("@book_id", id));
            _db.ExecuteNonQuery("DELETE FROM books WHERE id = @id",
                new SqliteParameter("@id", id));
        }

        // --- GET FROM DATABASE ---
        public async Task<Book> GetBookByIsbnAsync(string isbn)
        {
            string sql = "SELECT * FROM books WHERE isbn = @isbn LIMIT 1";
            var dt = await _db.ExecuteQueryAsync(sql, new SqliteParameter("@isbn", isbn));

            if (dt.Rows.Count == 0)
                return null;

            return MapFromDataRow(dt.Rows[0]);
        }

        // --- GET METADATA FROM API ---
        public async Task<BookMetadata> GetBookMetadataByIsbnAsync(string isbn)
        {
            using var client = new HttpClient();

            var url = $"https://openlibrary.org/isbn/{isbn}.json";
            try
            {
                var json = await client.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);

                var meta = new BookMetadata
                {
                    Title = doc.RootElement.TryGetProperty("title", out var titleEl) ? titleEl.GetString() : string.Empty,
                    Pages = doc.RootElement.TryGetProperty("number_of_pages", out var pagesEl) ? pagesEl.GetInt32() : 0,
                    Description = doc.RootElement.TryGetProperty("description", out var descEl)
                        ? (descEl.ValueKind == JsonValueKind.Object ? descEl.GetProperty("value").GetString() : descEl.GetString())
                        : string.Empty,
                    Publisher = doc.RootElement.TryGetProperty("publishers", out var pubEl) && pubEl.GetArrayLength() > 0
                        ? pubEl[0].GetString()
                        : string.Empty
                };

                // Autorzy
                if (doc.RootElement.TryGetProperty("authors", out var authorsEl))
                {
                    foreach (var a in authorsEl.EnumerateArray())
                    {
                        if (a.TryGetProperty("key", out var key))
                            meta.Authors.Add(key.GetString());
                    }
                }

                // Okładka (korzystamy z serwera covers.openlibrary.org)
                meta.CoverUrl = $"https://covers.openlibrary.org/b/isbn/{isbn}-L.jpg";

                return meta;
            }
            catch
            {
                return new BookMetadata { Title = $"ISBN {isbn} (brak danych w OpenLibrary)" };
            }
        }

        // --- GENRES ---
        public IEnumerable<Genre> GetAllGenres()
        {
            var list = new List<Genre>();
            string sql = "SELECT id, name FROM genres ORDER BY name";
            var dt = _db.ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Genre
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString()
                });
            }

            return list;
        }

        // --- MAPPER ---
        private Book MapFromDataRow(DataRow row)
        {
            return new Book
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"].ToString(),
                Isbn = row["isbn"].ToString(),
                PublisherId = row["publisher_id"] != DBNull.Value ? Convert.ToInt32(row["publisher_id"]) : 0,
                SeriesId = row["series_id"] != DBNull.Value ? Convert.ToInt32(row["series_id"]) : 0,
                SeriesNumber = row["series_number"] != DBNull.Value ? Convert.ToInt32(row["series_number"]) : (int?)null,
                Tome = row["tome"] != DBNull.Value ? Convert.ToInt32(row["tome"]) : (int?)null,
                Year = row["year"] != DBNull.Value ? Convert.ToInt32(row["year"]) : (int?)null,
                Description = row["notes"]?.ToString() ?? string.Empty
            };
        }
    }
}
