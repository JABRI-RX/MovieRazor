using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learnRazor.Dtos.Movie;

public class UpdateMovieDto
{
    [MaxLength(100)]
    public string? Title { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }
    public IList<string> Genres { get; set; } = [];
    [Column(TypeName ="decimal(18,2)")]
    public decimal Price { get; set; }
    [Required]
    [DefaultValue("https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg")]
    [MaxLength(200)]
    public string ImagUrl { get; set; } = string.Empty;
}