namespace learnRazor.Dtos.Movie;

public class ReadMovieDto
{
    public string? Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public IList<string> Genres { get; set; } = [];
    public double Price { get; set; }
    public string ImagUrl { get; set; } = string.Empty;
}