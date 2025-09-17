using System.Collections.Generic;

namespace Pagino_Teka.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }

        // Relacje
        public int PublisherId { get; set; }
        public int SeriesId { get; set; }

        public int? SeriesNumber { get; set; }
        public int? Tome { get; set; }
        public int? Year { get; set; }

        // Dodatkowe dane
        public int Pages { get; set; }          // liczba stron
        public int ReadTime { get; set; }       // czas czytania (opcjonalnie liczony)
        public string Description { get; set; }
        public string AuthorsText { get; set; }
        public string ImagePath { get; set; }

        // dla wygody formularza
        public string PublisherName { get; set; }
        public string SeriesName { get; set; }

        // Gatunki
        public List<int> GenreIds { get; set; } = new List<int>();
    }
}
