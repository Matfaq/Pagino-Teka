using Pagino_Teka.Database;
using Pagino_Teka.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pagino_Teka.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepo;
        private readonly AuthorRepository _authorRepo;
        private readonly BookSeriesRepository _seriesRepo;
        private readonly PublisherRepository _publisherRepo;

        public BookService(DatabaseService dbService)
        {
            _bookRepo = new BookRepository(dbService);
            _authorRepo = new AuthorRepository(dbService);
            _seriesRepo = new BookSeriesRepository(dbService);
            _publisherRepo = new PublisherRepository(dbService);
        }

        public void SaveBook(Book book, List<Genre> selectedGenres)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (selectedGenres == null || selectedGenres.Count == 0)
                throw new ArgumentException("Wybierz co najmniej jeden gatunek.");

            int publisherId = _publisherRepo.AddPublisherIfNotExists(book.PublisherName);

            int? seriesId = null;
            if (!string.IsNullOrWhiteSpace(book.SeriesName))
                seriesId = _seriesRepo.AddSeriesIfNotExists(book.SeriesName);

            var authorNames = (book.AuthorsText ?? string.Empty)
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .Where(a => a.Length > 0)
                .ToList();

            if (authorNames.Count == 0)
                throw new ArgumentException("Podaj co najmniej jednego autora.");

            int mainAuthorId = _authorRepo.AddAuthorIfNotExists(authorNames[0]);
            int genreId = selectedGenres.First().Id;

            string imagePath = !string.IsNullOrWhiteSpace(book.ImagePath) && File.Exists(book.ImagePath)
                ? Path.GetFullPath(book.ImagePath)
                : string.Empty;

            int bookId = _bookRepo.AddBook(
                book.Title,
                mainAuthorId,
                genreId,
                book.Isbn,
                book.Pages,
                book.ReadTime,
                seriesId,
                book.SeriesNumber,
                "", // publishedKind
                "", // adaptation
                publisherId,
                imagePath,
                book.Description
            );

            foreach (var a in authorNames.Skip(1))
            {
                int authorId = _authorRepo.AddAuthorIfNotExists(a);
                _bookRepo.AddBookAuthor(bookId, authorId);
            }

            book.Id = bookId;
        }

        public void UpdateBook(Book book, string authorsText, List<Genre> selectedGenres)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            book.AuthorsText = authorsText;
            _bookRepo.UpdateBook(
                book.Id,
                book.Title,
                _authorRepo.AddAuthorIfNotExists(authorsText.Split(',')[0].Trim()),
                selectedGenres.First().Id,
                book.Isbn,
                book.Pages,
                book.ReadTime,
                book.SeriesId,
                book.SeriesNumber,
                "", "", // publishedKind, adaptation
                _publisherRepo.AddPublisherIfNotExists(book.PublisherName),
                book.ImagePath,
                book.Description
            );

            _bookRepo.ClearBookAuthors(book.Id);

            var authorNames = (authorsText ?? string.Empty)
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .Where(a => a.Length > 0)
                .ToList();

            foreach (var a in authorNames)
            {
                int authorId = _authorRepo.AddAuthorIfNotExists(a);
                _bookRepo.AddBookAuthor(book.Id, authorId);
            }
        }

        public void DeleteBook(int bookId)
        {
            _bookRepo.DeleteBook(bookId);
        }

        public List<Genre> GetGenres() => _bookRepo.GetAllGenres();
    }
}
