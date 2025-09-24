public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;

    public int AuthorId { get; set; } // zgodnie ze schematem
    public int GenreId { get; set; } // zgodnie ze schematem (jeśli obsługujesz pojedynczy gatunek)
    public int PublisherId { get; set; }
    public int BookSeriesId { get; set; }
    public int? Tome { get; set; }
    public int Pages { get; set; }
    public int ReadTime { get; set; }
    public string PublishedKind { get; set; } = string.Empty;
    public string Adaptation { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Jeśli obsługujesz wiele gatunków, trzymaj List<int> GenreIds i relację w osobnej tabeli
    public List<int> GenreIds { get; set; } = new();
    
    public string AuthorName { get; set; } // tylko do odczytu, nie mapowane do bazy
}