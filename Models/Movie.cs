using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learnRazor.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public IList<string> Genres { get; set; } = [];
    public decimal Price { get; set; }
    public string ImagUrl { get; set; } = string.Empty;
}