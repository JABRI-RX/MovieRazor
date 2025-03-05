using learnRazor.Data;
using learnRazor.Interfaces;
using learnRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace learnRazor.Repostories;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> CreateAsync(Movie movie)
    {
        _context.Add(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<bool> DeleteMovieByIdAsync(int movieId)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m=>m.Id.Equals(movieId));
        if (movie is null)
            return false;
        _context.Remove(movie);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteMovieByNameAsync(string movieName)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m=>m.Title.Equals(movieName));
        if (movie is null)
            return false;
        _context.Remove(movie);
        await _context.SaveChangesAsync();
        return true;    }

    public Task<Movie> UpdateMovieAsync(Movie movie)
    {
        // var 
        throw new NotImplementedException();
    }

    public async Task<IList<Movie>> GetAllMoviesAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetMovieByIdAsync(int movieId)
    {
        return await _context.Movies.FirstOrDefaultAsync(m => m.Id.Equals(movieId));
    }

    public async Task<IList<Movie>?> GetMovieByTitleAsync(string movieTitle)
    {
        return await _context.Movies.AsQueryable()
            .Where(m=>m.Title.Contains(movieTitle))
            .ToListAsync();
    }

    public async Task<IList<Movie>?> GetMoviesByYearAsync(string dateRelease)
    {
        var movies = _context.Movies.AsQueryable();
        return await movies
            .Where(
                m => m.ReleaseDate.Equals(DateTime.Parse(dateRelease))
                ).ToListAsync();
    }

    public async Task<IList<Movie>?> GetMoviesByGenreAsync(IList<string> genres)
    {
        var movies = _context.Movies.AsQueryable();
        foreach (var genre in genres)
        {
            movies = movies.Where(m => m.Genres.Contains(genre));
        }

        return await movies.ToListAsync();
    }

    public IQueryable<Movie> GetMoviesAsQueryable()
    {
        return _context.Movies.AsQueryable();
    }
}