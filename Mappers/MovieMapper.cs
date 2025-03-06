using learnRazor.Dtos.Movie;
using learnRazor.Models;

namespace learnRazor.Mappers;

public static class MovieMapper
{
    public static ReadMovieDto ToMovieDto(Movie movie)
    {
        return new ReadMovieDto
        {
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price,
            ImagUrl = movie.ImagUrl,
            Genres = movie.Genres
        };
    }
    public static Movie FromCreateDtoToMovie(CreateMovieDto movie)
    {
        return new Movie()
        {
            Title = movie.Title,
            ReleaseDate = movie.ReleaseDate,
            Price = movie.Price,
            ImagUrl = movie.ImagUrl,
            Genres = movie.Genres
        };
    }
    
}