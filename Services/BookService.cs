using Pagino_Teka.Database;
using Pagino_Teka.Models;
using Pagino_Teka.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pagino_Teka.Services
{
    /// <summary>
    /// Serwis do obsługi logiki biznesowej książek.
    /// </summary>
    public class BookService
    {
        private readonly DatabaseService _db;

        public BookRepository BookRepository { get; }
        public AuthorRepository AuthorRepository { get; }
        public BookSeriesRepository BookSeriesRepository { get; }
        public PublisherRepository PublisherRepository { get; }

        private static BookService _instance;
        public static BookService Instance => _instance ??= new BookService(DatabaseService.Instance);

        public BookService(DatabaseService databaseService)
        {
            _db = databaseService;
            BookRepository = new BookRepository(_db);
            AuthorRepository = new AuthorRepository(_db);
            BookSeriesRepository = new BookSeriesRepository(_db);
            PublisherRepository = new PublisherRepository(_db);
        }

        /// <summary>
        /// Pobiera i scala dane z OpenLibrary i Google Books.
        /// </summary>
        public async Task<BookMetadata> GetBookByIsbnAsync(string isbn)
        {
            var openMeta = await BookRepository.GetBookMetadataByIsbnAsync(isbn);

            BookMetadata googleMeta = null;
            string apiKey = LoadGoogleApiKey();
            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                googleMeta = await BookRepository.GetBookMetadataFromGoogleAsync(isbn, apiKey);
            }

            var result = new BookMetadata
            {
                Title = !string.IsNullOrWhiteSpace(openMeta?.Title) ? openMeta.Title : googleMeta?.Title,
                Description = !string.IsNullOrWhiteSpace(openMeta?.Description) ? openMeta.Description : googleMeta?.Description,
                Pages = openMeta?.Pages > 0 ? openMeta.Pages : (googleMeta?.Pages ?? 0),
                Publisher = !string.IsNullOrWhiteSpace(openMeta?.Publisher) ? openMeta.Publisher : googleMeta?.Publisher,
                CoverUrl = !string.IsNullOrWhiteSpace(googleMeta?.CoverUrl) ? googleMeta.CoverUrl : openMeta?.CoverUrl,
                Series = googleMeta?.Series ?? openMeta?.Series,
                Tome = googleMeta?.Tome ?? openMeta?.Tome
            };

            if (openMeta?.Authors != null)
                result.Authors.AddRange(openMeta.Authors);
            if (googleMeta?.Authors != null)
                result.Authors.AddRange(googleMeta.Authors);

            result.Authors = result.Authors.Distinct().ToList();

            if (googleMeta?.Genres != null && googleMeta.Genres.Any())
                result.Genres = googleMeta.Genres;

            return result;
        }

        public IEnumerable<Genre> GetAllGenres() => BookRepository.GetAllGenres();
        public IEnumerable<Publisher> GetAllPublishers() => PublisherRepository.GetAll();
        public IEnumerable<BookSeries> GetAllSeries() => BookSeriesRepository.GetAll();

        public Publisher AddPublisherIfNotExists(string name) => PublisherRepository.AddIfNotExists(name);

        public void SaveBook(Book book) => BookRepository.Add(book);
        public void UpdateBook(Book book) => BookRepository.Update(book);
        public void DeleteBook(int bookId) => BookRepository.Delete(bookId);

        // ✅ Wczytywanie klucza Google API z user_settings.json
        private string LoadGoogleApiKey()
        {
            try
            {
                string appFolder = _db.GetAppFolderPath();
                string settingsFile = Path.Combine(appFolder, "user_settings.json");

                if (File.Exists(settingsFile))
                {
                    var json = File.ReadAllText(settingsFile);
                    var settings = JsonSerializer.Deserialize<UserSettings>(json);
                    if (settings != null && settings.UseGoogleApi)
                        return settings.GoogleApiKey;
                }
            }
            catch { }
            return string.Empty;
        }

        private class UserSettings
        {
            public bool UseGoogleApi { get; set; }
            public string GoogleApiKey { get; set; } = string.Empty;
        }
    }
}
