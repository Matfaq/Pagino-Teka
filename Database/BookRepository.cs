using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pagino_Teka.Database
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
            string sql = @"INSERT INTO books (title, isbn, author_id, genre_id, publisher_id, book_series_id, tome, pages, read_time, published_kind, adaptation, image, description)
                           VALUES (@title, @isbn, @auth, @genre, @pub, @series, @tome, @pages, @read, @kind, @adapt, @img, @desc);
                           SELECT last_insert_rowid();";

            var id = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqliteParameter("@title", book.Title),
                new SqliteParameter("@isbn", book.Isbn),
                new SqliteParameter("@auth", book.AuthorId),
                new SqliteParameter("@genre", book.GenreId),
                new SqliteParameter("@pub", book.PublisherId),
                new SqliteParameter("@series", book.BookSeriesId > 0 ? (object)book.BookSeriesId : DBNull.Value),
                new SqliteParameter("@tome", book.Tome ?? (object)DBNull.Value),
                new SqliteParameter("@pages", book.Pages),
                new SqliteParameter("@read", book.ReadTime),
                new SqliteParameter("@kind", book.PublishedKind ?? string.Empty),
                new SqliteParameter("@adapt", book.Adaptation ?? string.Empty),
                new SqliteParameter("@img", book.Image ?? string.Empty),
                new SqliteParameter("@desc", book.Description ?? string.Empty)
            ));

            book.Id = id;

            // Jeśli obsługujesz wiele gatunków, zapisz relacje w tabeli powiązań
            foreach (var genreId in book.GenreIds)
            {
                _db.ExecuteNonQuery("INSERT INTO BookGenres (book_id, genre_id) VALUES (@book_id, @genre_id)",
                    new SqliteParameter("@book_id", id),
                    new SqliteParameter("@genre_id", genreId));
            }
        }

        // --- UPDATE ---
        public void Update(Book book)
        {
            string sql = @"UPDATE books SET
                           title = @title,
                           isbn = @isbn,
                           author_id = @auth,
                           genre_id = @genre,
                           publisher_id = @pub,
                           book_series_id = @series,
                           tome = @tome,
                           pages = @pages,
                           read_time = @read,
                           published_kind = @kind,
                           adaptation = @adapt,
                           image = @img,
                           description = @desc
                           WHERE id = @id";

            _db.ExecuteNonQuery(sql,
                new SqliteParameter("@title", book.Title),
                new SqliteParameter("@isbn", book.Isbn),
                new SqliteParameter("@auth", book.AuthorId),
                new SqliteParameter("@genre", book.GenreId),
                new SqliteParameter("@pub", book.PublisherId),
                new SqliteParameter("@series", book.BookSeriesId > 0 ? (object)book.BookSeriesId : DBNull.Value),
                new SqliteParameter("@tome", book.Tome ?? (object)DBNull.Value),
                new SqliteParameter("@pages", book.Pages),
                new SqliteParameter("@read", book.ReadTime),
                new SqliteParameter("@kind", book.PublishedKind ?? string.Empty),
                new SqliteParameter("@adapt", book.Adaptation ?? string.Empty),
                new SqliteParameter("@img", book.Image ?? string.Empty),
                new SqliteParameter("@desc", book.Description ?? string.Empty),
                new SqliteParameter("@id", book.Id)
            );

            // Aktualizacja relacji gatunków
            _db.ExecuteNonQuery("DELETE FROM BookGenres WHERE book_id = @book_id",
                new SqliteParameter("@book_id", book.Id));
            foreach (var genreId in book.GenreIds)
            {
                _db.ExecuteNonQuery("INSERT INTO BookGenres (book_id, genre_id) VALUES (@book_id, @genre_id)",
                    new SqliteParameter("@book_id", book.Id),
                    new SqliteParameter("@genre_id", genreId));
            }
        }

        // --- DELETE ---
        public void Delete(int id)
        {
            _db.ExecuteNonQuery("DELETE FROM BookGenres WHERE book_id = @book_id",
                new SqliteParameter("@book_id", id));
            _db.ExecuteNonQuery("DELETE FROM books WHERE id = @id",
                new SqliteParameter("@id", id));
        }

        // --- GET FROM DATABASE ---
        public async Task<Book?> GetBookByIsbnAsync(string isbn)
        {
            string sql = "SELECT * FROM books WHERE isbn = @isbn LIMIT 1";
            var dt = await _db.ExecuteQueryAsync(sql, new SqliteParameter("@isbn", isbn));

            if (dt.Rows.Count == 0)
                return null;

            return MapFromDataRow(dt.Rows[0]);
        }

        // --- GET METADATA FROM OPENLIBRARY ---
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
                    Title = doc.RootElement.TryGetProperty("title", out var titleEl) && titleEl.GetString() != null ? titleEl.GetString()! : string.Empty,
                    Pages = doc.RootElement.TryGetProperty("number_of_pages", out var pagesEl) ? pagesEl.GetInt32() : 0,
                    Description = doc.RootElement.TryGetProperty("description", out var descEl)
                        ? (descEl.ValueKind == JsonValueKind.Object ? descEl.GetProperty("value").GetString() ?? string.Empty : descEl.GetString() ?? string.Empty)
                        : string.Empty,
                    Publisher = doc.RootElement.TryGetProperty("publishers", out var pubEl) && pubEl.GetArrayLength() > 0 && pubEl[0].GetString() != null
                        ? pubEl[0].GetString()!
                        : string.Empty,
                    CoverUrl = $"https://covers.openlibrary.org/b/isbn/{isbn}-L.jpg"
                };

                return meta;
            }
            catch
            {
                return new BookMetadata { Title = $"ISBN {isbn} (brak danych w OpenLibrary)" };
            }
        }

        // --- GET METADATA FROM GOOGLE BOOKS ---
        public async Task<BookMetadata?> GetBookMetadataFromGoogleAsync(string isbn, string apiKey)
        {
            using var client = new HttpClient();
            var url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&key={apiKey}";

            try
            {
                var json = await client.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);

                if (!doc.RootElement.TryGetProperty("items", out var items) || items.GetArrayLength() == 0)
                    return null;

                var volumeInfo = items[0].GetProperty("volumeInfo");

                var meta = new BookMetadata
                {
                    Title = volumeInfo.TryGetProperty("title", out var titleEl) && titleEl.GetString() != null ? titleEl.GetString()! : string.Empty,
                    Pages = volumeInfo.TryGetProperty("pageCount", out var pagesEl) ? pagesEl.GetInt32() : 0,
                    Description = volumeInfo.TryGetProperty("description", out var descEl) && descEl.GetString() != null ? descEl.GetString()! : string.Empty,
                    Publisher = volumeInfo.TryGetProperty("publisher", out var pubEl) && pubEl.GetString() != null ? pubEl.GetString()! : string.Empty
                };

                if (volumeInfo.TryGetProperty("authors", out var authorsEl))
                {
                    foreach (var a in authorsEl.EnumerateArray())
                    {
                        var authorName = a.GetString();
                        if (authorName != null)
                            meta.Authors.Add(authorName);
                    }
                }

                if (volumeInfo.TryGetProperty("categories", out var catEl))
                {
                    foreach (var c in catEl.EnumerateArray())
                    {
                        var genre = c.GetString();
                        if (genre != null)
                            meta.Genres.Add(genre);
                    }
                }

                if (volumeInfo.TryGetProperty("imageLinks", out var imgEl) &&
                    imgEl.TryGetProperty("thumbnail", out var thumbEl) &&
                    thumbEl.GetString() != null)
                {
                    meta.CoverUrl = thumbEl.GetString()!;
                }

                return meta;
            }
            catch
            {
                return null;
            }
        }

        // --- GENRES (lista wszystkich dostępnych gatunków z tabeli Genres) ---
        public IEnumerable<Genre> GetAllGenres()
        {
            var list = new List<Genre>();
            string sql = "SELECT id, name FROM BookGenres ORDER BY name";
            var dt = _db.ExecuteQuery(sql);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Genre
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"]?.ToString() ?? string.Empty
                });
            }

            return list;
        }

        // --- MAPPER ---
        private Book MapFromDataRow(DataRow row)
        {
            var book = new Book
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"]?.ToString() ?? string.Empty,
                Isbn = row["isbn"]?.ToString() ?? string.Empty,
                AuthorId = row["author_id"] != DBNull.Value ? Convert.ToInt32(row["author_id"]) : 0,
                GenreId = row["genre_id"] != DBNull.Value ? Convert.ToInt32(row["genre_id"]) : 0,
                PublisherId = row["publisher_id"] != DBNull.Value ? Convert.ToInt32(row["publisher_id"]) : 0,
                BookSeriesId = row["book_series_id"] != DBNull.Value ? Convert.ToInt32(row["book_series_id"]) : 0,
                Tome = row["tome"] != DBNull.Value ? Convert.ToInt32(row["tome"]) : (int?)null,
                Pages = row["pages"] != DBNull.Value ? Convert.ToInt32(row["pages"]) : 0,
                ReadTime = row["read_time"] != DBNull.Value ? Convert.ToInt32(row["read_time"]) : 0,
                PublishedKind = row["published_kind"]?.ToString() ?? string.Empty,
                Adaptation = row["adaptation"]?.ToString() ?? string.Empty,
                Image = row["image"]?.ToString() ?? string.Empty,
                Description = row["description"]?.ToString() ?? string.Empty,
                GenreIds = GetGenreIdsForBook(Convert.ToInt32(row["id"]))
            };
            // Ustaw AuthorName jeśli jest w DataRow (np. po JOIN)
            if (row.Table.Columns.Contains("author_name"))
                book.AuthorName = row["author_name"]?.ToString() ?? "";
            return book;
        }

        private List<int> GetGenreIdsForBook(int bookId)
        {
            var genreIds = new List<int>();
            string sql = "SELECT genre_id FROM BookGenresMap WHERE book_id = @book_id";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@book_id", bookId));
            foreach (DataRow r in dt.Rows)
                genreIds.Add(Convert.ToInt32(r["genre_id"]));
            return genreIds;
        }

        // --- FIND BY TITLE ---
        public IEnumerable<Book> FindByTitle(string title)
        {
            string sql = @"SELECT b.*, a.name AS author_name
                           FROM books b
                           JOIN Authors a ON b.author_id = a.id
                           WHERE b.title LIKE @title";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@title", $"%{title}%"));
            foreach (DataRow row in dt.Rows)
            {
                var book = MapFromDataRow(row);
                yield return book;
            }
        }

        // --- FIND BY AUTHOR ---
        public IEnumerable<Book> FindByAuthor(string author)
        {
            string sql = @"SELECT b.*, a.name AS author_name
                           FROM books b
                           JOIN Authors a ON b.author_id = a.id
                           WHERE a.name LIKE @author";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@author", $"%{author}%"));
            foreach (DataRow row in dt.Rows)
            {
                var book = MapFromDataRow(row);
                yield return book;
            }
        }

        // --- FIND BY SERIES ---
        public IEnumerable<Book> FindBySeries(string series)
        {
            string sql = @"SELECT b.*, a.name AS author_name
                           FROM books b
                           JOIN Authors a ON b.author_id = a.id
                           JOIN BookSeries s ON b.book_series_id = s.id
                           WHERE s.name LIKE @series";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@series", $"%{series}%"));
            foreach (DataRow row in dt.Rows)
            {
                var book = MapFromDataRow(row);
                yield return book;
            }
        }

        // --- FIND BY PUBLISHER ---
        public IEnumerable<Book> FindByPublisher(string publisher)
        {
            string sql = @"SELECT b.*, a.name AS author_name
                           FROM books b
                           JOIN Authors a ON b.author_id = a.id
                           JOIN Publishers p ON b.publisher_id = p.id
                           WHERE p.name LIKE @publisher";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@publisher", $"%{publisher}%"));
            foreach (DataRow row in dt.Rows)
            {
                var book = MapFromDataRow(row);
                yield return book;
            }
        }
    }
}
