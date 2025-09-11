namespace Pagino_Teka.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public int Pages { get; set; }
        public int ReadTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        public string AuthorsText { get; set; } = string.Empty;

        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = string.Empty;

        public int? SeriesId { get; set; }
        public string SeriesName { get; set; } = string.Empty;

        public int? SeriesNumber { get; set; } = null;
        public int GenreId { get; set; }
    }
}
