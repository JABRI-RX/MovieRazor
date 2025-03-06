using learnRazor.Data;
using learnRazor.Interfaces;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace learnRazor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(AppDbContext context,ILogger<IndexModel> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string?  Genre { get; set; }

        [BindProperty(SupportsGet = true)] 
        public decimal MinPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public decimal MaxPrice { get; set; }
        // [BindProperty(SupportsGet = true)]
        // public DateTime DatePublisher { get; set; }
        public async Task OnGetAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = await _movieRepository.GetMovieByTitleAsync(SearchString);
            }

            if (  !string.IsNullOrEmpty(Genre) && !Genre.Contains("Genre"))
            {
                movies = await _movieRepository.GetMoviesByGenreAsync([Genre]);
            }

            if (MinPrice > 0 && MaxPrice > 0 && MinPrice < MaxPrice)
            {
                // movies = movies.Where(m => m.Price < MaxPrice && m.Price > MinPrice);
            }
            Movie = ;


        }
    }
}
