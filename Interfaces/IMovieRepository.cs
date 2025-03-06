using learnRazor.Dtos.Movie;
using learnRazor.Models;

namespace learnRazor.Interfaces;

public interface IMovieRepository
{
    Task<Movie> CreateAsync(Movie movie);
    Task<bool> DeleteMovieByIdAsync(int movieId);
    Task<bool> DeleteMovieByNameAsync(string movieName);
    Task<Movie> UpdateMovieAsync(Movie movie );
    Task<IList<Movie>> GetAllMoviesAsync();
    Task<Movie?> GetMovieByIdAsync(int movieId);
    Task<IList<Movie>?> GetMovieByTitleAsync(string movieTitle);
    Task<IList<Movie>?> GetMoviesByYearAsync(string dateRelease);
    Task<IList<Movie>?> GetMoviesByGenreAsync(IList<string> genres);
}