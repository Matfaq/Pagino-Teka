using Pagino_Teka.Database;
using Pagino_Teka.Models;
using Pagino_Teka.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pagino_Teka.Services
{
    public class BookService
    {
        public BookRepository BookRepository { get; }
        public AuthorRepository AuthorRepository { get; }
        public PublisherRepository PublisherRepository { get; }
        public BookSeriesRepository BookSeriesRepository { get; }

        public BookService(DatabaseService databaseService)
        {
            if (databaseService == null)
                throw new ArgumentNullException(nameof(databaseService));

            BookRepository = new BookRepository(databaseService);
            AuthorRepository = new AuthorRepository(databaseService);
            PublisherRepository = new PublisherRepository(databaseService);
            BookSeriesRepository = new BookSeriesRepository(databaseService);
        }

        // --- GET methods ---

        public IEnumerable<Publisher> GetAllPublishers()
        {
            return PublisherRepository.GetAll();
        }

        public IEnumerable<BookSeries> GetAllSeries()
        {
            return BookSeriesRepository.GetAll();
        }

        // Ładowanie gatunków jest obsługiwane w BookRepository (a nie przez osobny repozytorium)
        public IEnumerable<Genre> GetAllGenres()
        {
            return BookRepository.GetAllGenres();
        }

        public async Task<Book> GetBookByIsbnAsync(string isbn)
        {
            return await BookRepository.GetBookByIsbnAsync(isbn);
        }

        // Dodanie wydawcy jeśli nie istnieje
        public Publisher AddPublisherIfNotExists(string publisherName)
        {
            if (string.IsNullOrWhiteSpace(publisherName))
                return null;

            return PublisherRepository.AddIfNotExists(publisherName.Trim());
        }

        // --- SAVE / UPDATE / DELETE ---

        public void SaveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            BookRepository.Add(book);
        }

        public void UpdateBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            BookRepository.Update(book);
        }

        public void DeleteBook(int bookId)
        {
            if (bookId <= 0) throw new ArgumentException("Niepoprawne ID książki.");
            BookRepository.Delete(bookId);
        }
    }
}
