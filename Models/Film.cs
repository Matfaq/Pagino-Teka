public class Film
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int DirectorId { get; set; }
    // Zmień z pojedynczego ID na listę ID scenarzystów:
    public List<int> ScreenwriterIds { get; set; } = new List<int>();
    public int? Year { get; set; }
    public int? Duration { get; set; } // czas trwania w minutach
    public string Country { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<int> GenreIds { get; set; } = new();
    public string BasedOn { get; set; } = string.Empty;
    public string DirectorName { get; set; } = string.Empty;
    // Dodaj listę nazw scenarzystów do wygodnego wyświetlania w UI:
    public List<string> ScreenwriterNames { get; set; } = new List<string>();
}