using Seminar2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2
{
    public class MovieSeeder
    {
        public static void Initialize(MovieDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            context.Movies.AddRange(
                new Movie
                {
                    Title="Ironmen",
                    Description = "blablablab",
                    Genre="action",
                    Duration=120,
                    YearRelease=2015,
                    Director="un nene",
                    DateAdded= new DateTime(2017, 1, 18),
                    Rating =8,
                    Watched=false


                },
                new Movie
                {
                    Title = "Batman",
                    Description = "blablablab",
                    Genre = "action",
                    Duration = 120,
                    YearRelease = 2015,
                    Director = "un nene",
                    DateAdded = new DateTime(2017, 5, 18),
                    Rating = 8,
                    Watched = false

                }
            );
            context.SaveChanges();
        }
    }
}
