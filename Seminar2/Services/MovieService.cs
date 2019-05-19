using Microsoft.EntityFrameworkCore;
using Seminar2.Model;
using Seminar2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        IEnumerable<MovieGetModel> GetAll(DateTime? from = null, DateTime? to = null);
        Movie GetById(int id);
        Movie Create(MoviePostModel movie);
        Movie Upsert(int id, Movie movie);
        Movie Delete(int id);
    }


    public class MovieService : IMovieService

    {
        MovieDbContext context;

        public MovieService(MovieDbContext context)
        {
            this.context = context;
        }



        public Movie Create(MoviePostModel movie)
        {
            Movie toAdd = MoviePostModel.ToMovie(movie);
            context.Movies.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Movie Delete(int id)
        {
            var existing = context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Movies.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public IEnumerable<MovieGetModel> GetAll(DateTime? from = null, DateTime? to = null)
        {
            IQueryable<Movie> result = context
                .Movies
                .Include(f => f.Comments);
            if (from == null && to == null)
            {
                return result.Select(f => MovieGetModel.FromMovie(f));
            }
            if (from != null)
            {
                result = result.Where(f => f.DateAdded >= from);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }
            result = result.OrderBy(x => x.YearRelease);
            return result.Select(f => MovieGetModel.FromMovie(f));
        }

        public Movie GetById(int id)
        {
            return context.Movies.Include(f => f.Comments)
                .FirstOrDefault(f => f.Id == id);
        }

        public Movie Upsert(int id, Movie movie)
        {
            var existing = context.Movies.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                return movie;
            }
            movie.Id = id;
            context.Movies.Update(movie);
            context.SaveChanges();
            return movie;
        }
    }
}
