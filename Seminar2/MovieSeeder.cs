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
                    Title = "ironmen",
                    Description = "blablablab",
                    Genre = Genre.action,
                    Duration = 120,
                    YearRelease = 2015,
                    Director = "un nene",
                    DateAdded = new DateTime(2017, 1, 18),
                    Rating = 10,
                    watched = Watched.yes



                },
                new Movie
                {
                    Title = "batman",
                    Description = "blablablab",
                    Genre = Genre.action,
                    Duration = 120,
                    YearRelease = 2016,
                    Director = "un nene",
                    DateAdded = new DateTime(2017, 1, 24),
                    Rating = 8,
                    watched = Watched.yes

                },
                 new Movie
                 {
                     Title = "mica sirena",
                     Description = "blablablab",
                     Genre = Genre.comedy,
                     Duration = 120,
                     YearRelease = 2009,
                     Director = "un nene",
                     DateAdded = new DateTime(2017, 1, 30),
                     Rating = 7,
                     watched = Watched.no

                 }
            );
            context.SaveChanges();
        }
    }
}
