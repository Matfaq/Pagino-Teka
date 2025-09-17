using Pagino_Teka.Database;
using Pagino_Teka.Models;
using Pagino_Teka.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pagino_Teka.Services
{
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

        // --- gatunki
        public IEnumerable<Genre> GetAllGenres() => BookRepository.GetAllGenres();

        // --- wydawcy
        public IEnumerable<Publisher> GetAllPublishers() => PublisherRepository.GetAll();

        public Publisher AddPublisherIfNotExists(string name) => PublisherRepository.AddIfNotExists(name);

        // --- serie
        public IEnumerable<BookSeries> GetAllSeries() => BookSeriesRepository.GetAll();

        // --- ISBN API
        public async Task<BookMetadata> GetBookByIsbnAsync(string isbn) =>
            await BookRepository.GetBookMetadataByIsbnAsync(isbn);

        // --- zapis książki
        public void SaveBook(Book book) => BookRepository.Add(book);

        // aktualizacja i usuwanie
        public void UpdateBook(Book book) => BookRepository.Update(book);
        public void DeleteBook(int bookId) => BookRepository.Delete(bookId);
    }
}
