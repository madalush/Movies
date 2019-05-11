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
                    Genre=Genre.action,
                    Duration=120,
                    YearRelease=2015,
                    Director="un nene",
                    DateAdded= new DateTime(2017, 1, 18),
                    Rating =10,
                    Watched=false


                },
                new Movie
                {
                    Title = "Batman",
                    Description = "blablablab",
                    Genre = Genre.action,
                    Duration = 120,
                    YearRelease = 2016,
                    Director = "un nene",
                    DateAdded = new DateTime(2017, 1, 24),
                    Rating = 8,
                    Watched = false

                },
                 new Movie
                 {
                     Title = "Mica sirena",
                     Description = "blablablab",
                     Genre = Genre.comedy,
                     Duration = 120,
                     YearRelease = 2009,
                     Director = "un nene",
                     DateAdded = new DateTime(2017, 1, 30),
                     Rating = 7,
                     Watched = true

                 }
            );
            context.SaveChanges();
        }
    }
}
