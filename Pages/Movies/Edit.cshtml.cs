using learnRazor.Data;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace learnRazor.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public Dictionary<string, bool> Categories = new();
        public EditModel(learnRazor.Data.AppDbContext context)
        {
            _context = context;
           
        }

        public void LoadCategories()
        {
            var genres = Genres.GetGenres();
            foreach (var gen in genres)
            {
                if(Movie.Genres.Contains(gen))
                    Categories.Add(gen,true);
                else
                    Categories.Add(gen,false);
            }
            Console.WriteLine(Categories);
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie =  await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            Movie = movie;
            LoadCategories();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Request.Form["genres"].Count == 0)
            {
                LoadCategories();
                return Page();
            }

            // foreach (var genre in Request.Form["genres"])
            // {
            //     Movie.Genres.Add(genre);
            // }
            Movie.Genres.AddRange(Request.Form["genres"]);
            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        
            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
