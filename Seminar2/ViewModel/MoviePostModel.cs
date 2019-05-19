using Seminar2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2.ViewModel
{
    public class MoviePostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int YearRelease { get; set; }
        public string Director { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        public string watched { get; set; }
        public List<Comment> Comments { get; set; }

        public static Movie ToMovie(MoviePostModel movie)
        {   // action, comedy, horror, thriller }

            Genre genre = Model.Genre.action;
            if (movie.Genre == "comedy")
            {
                genre = Model.Genre.comedy;
            }
            else if (movie.Genre == "horror")
            {
                genre = Model.Genre.horror;
            }
            else if (movie.Genre == "thriller")
            {
                genre = Model.Genre.thriller;
            }

            Watched watched = Model.Watched.no;
            if (movie.watched == "yes")
            {
                watched = Model.Watched.yes;
            }

            return new Movie
            {
                Title = movie.Title,
                Description = movie.Description,

                Genre = genre,
                Duration = movie.Duration,
                YearRelease = movie.YearRelease,
                Director = movie.Director,
                DateAdded = movie.DateAdded,
                Rating = movie.Rating,
                watched = watched,
                Comments = movie.Comments

            };
        }


    }
}
