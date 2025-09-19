public class Film
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int DirectorId { get; set; }
    public int ScreenwriterId { get; set; } // <-- DODAJ TO POLE
    public int GenreId { get; set; }
    public int? Year { get; set; }
    public int? Duration { get; set; } // czas trwania w minutach
    public string Country { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<int> GenreIds { get; set; } = new();
    // DODAJ TO POLE:
    public string BasedOn { get; set; } = string.Empty;
}