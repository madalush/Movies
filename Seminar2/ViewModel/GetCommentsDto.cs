using Seminar2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2.ViewModel
{
    public class GetCommentsDto


    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Important { get; set; }

        public int MovieId { get; set; }

        //public static GetCommentsDto dtofrommodel(Comment comment)
        //{
        //    return new GetCommentsDto
        //    {
        //        Id = comment.Id,
        //        Text = comment.Text,
        //        Important = comment.Important,
        //        MovieId = (from movies in context.movies
        //                   where movies.id == x.movieid
        //                   select movies.id).firstordefault()
        //    };
        //}
    }
}
