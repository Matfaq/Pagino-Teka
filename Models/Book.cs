namespace Pagino_Teka.Models
{
    public class Book
    {
        public int Id { get; set; }

        // podstawowe
        public string Title { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;

        // metadane
        public int? Year { get; set; } = null;           // rok wydania (nullable)
        public int? Tome { get; set; } = null;           // tom / wolumin (nullable)
        public int Pages { get; set; }
        public int ReadTime { get; set; }

        // tekstowe reprezentacje autorów (stosowane w formularzach)
        public string AuthorsText { get; set; } = string.Empty;

        // jeżeli gdzieś używane są ID i nazwy wydawcy/serii
        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = string.Empty;

        public int? SeriesId { get; set; }
        public string SeriesName { get; set; } = string.Empty;
        public int? SeriesNumber { get; set; } = null;

        // pola używane przez repozytoria i formularze
        public int AuthorId { get; set; }                 // główny autor (id)
        public int GenreId { get; set; }                  // pojedynczy gatunek (jeśli tak to trzymasz)

        // opis i ścieżka obrazu
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
