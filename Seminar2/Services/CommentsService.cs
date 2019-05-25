using Seminar2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2.Services
{

    public interface ICommentService
    {
        IEnumerable<GetCommentsDto> GetComments(string text);
    }
    public class CommentsService : ICommentService
    {
        private MovieDbContext context;

        public CommentsService(MovieDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="text"> the text we are looking for </param>
        /// <returns></returns>
        public IEnumerable<GetCommentsDto> GetComments(string text)
        {
            IQueryable<GetCommentsDto> result = context.Comments.Select(x => new GetCommentsDto

            {



                Id = x.Id,
                Text = x.Text,
                Important = x.Important,
                MovieId = (from movies in context.Movies
                           where movies.Comments.Contains(x)
                           select movies.Id).FirstOrDefault()
            });


            if (text != null)
            {
                result = result.Where(comment => comment.Text.Contains(text));
            }

            return result;
        }

    }
}
