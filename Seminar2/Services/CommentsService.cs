using Seminar2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2.Services
{

    public interface ICommentService
    {
        IEnumerable<CommentListDto> GetComments(string text);
    }
    public class CommentsService : ICommentService
    {
        private MovieDbContext context;

        public CommentsService(MovieDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CommentListDto> GetComments(string text)
        {
            IQueryable<GetCommentsDto> result = context.Comments.Select(x => new GetCommentsDto
            {
                Id = x.Id,
                Text = x.Text,
                Important = x.Important,
                MovieId = (from Movies in context.Movies
                           where Movies.Id == x.MovieId
                           select Movies.Id).FirstOrDefault()
            });
            //var result = context.Comments.Select(x 

            if (text != null)
            {
                result = result.Where(comment => comment.Text.Contains(text));
            }

            yield return new CommentListDto
            {
                CommentsList = result
            };
        }

    }
}
