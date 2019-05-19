using Seminar2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2.ViewModel
{
    public class MovieGetModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }
        public int Duration { get; set; }
        public int YearRelease { get; set; }
        public string Director { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        [EnumDataType(typeof(Watched))]
        public Watched watched { get; set; }
        //  public List<Comment> Comments { get; set; }
        public int NumberOfComments { get; set; }

        public static MovieGetModel FromMovie(Movie movie)
        {
            return new MovieGetModel
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Duration = movie.Duration,
                YearRelease = movie.YearRelease,
                Director = movie.Director,
                DateAdded = movie.DateAdded,
                Rating = movie.Rating,
                watched = movie.watched,
                NumberOfComments = movie.Comments.Count
            };
        }

    }
}
