using learnRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace learnRazor.Data;

public static class SeedData
{
    public static void InitSeedData(this IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context is null || context.Movies is null)
                throw new ArgumentNullException("null AppDbContext");
            if (context.Movies.Any())
                return;
            context.Movies.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genres = ["Romantic","Comedy"],
                    Price = 7.99,
                    ImagUrl = "https://m.media-amazon.com/images/I/61SuGcS9AvL.jpg"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genres = ["Comedy","Horror"],
                    Price = 8.99,
                    ImagUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTylsuAYz-pPG9Cvj4R4sZGnnollN65RyrWuy8vU_J7JA8mf42CPafkCK_I72wdkAOo6xph3w",
                    
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genres = ["Comedy","Horror"],
                    Price = 9.99,
                    ImagUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRvzyU2UZq24hN0eJ2uwFcpdkDXaIiLdtXIhQoRQD_csg0bhzHaFJdw5mV2vvdg5NS9coK0NQ"
                    
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genres = ["Western","Action"],
                    Price = 3.99,
                    ImagUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRe5mcelZKHW7TAbs5kE2MNIGcOlOWg_FfQ0r-pMGis68W6AYnwq1eot4aVX2rphP8sA6Cl"
                    
                });
            context.SaveChanges();
        }
    }
}