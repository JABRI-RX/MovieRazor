using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using learnRazor.Data;
using learnRazor.Models;
using NuGet.Packaging;

namespace learnRazor.Pages_Movies
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CreateModel> _logger;
        public CreateModel(learnRazor.Data.AppDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
            LoadGenres = Data.Genres.GetGenres();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Movie Movie { get; set; } = default!;

        public IList<string> LoadGenres { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Request.Form["genres"].Count == 0)
            {
                return Page();
            }
            Console.WriteLine();
            Movie.Genres.AddRange(Request.Form["genres"]);
            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}