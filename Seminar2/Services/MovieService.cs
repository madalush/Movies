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
        /// Finds all movies 
        /// </summary>
        /// <param name="from"> </param>
        /// <param name="to"></param>
        /// <returns>a list of MovieGetModel</returns>
        PaginatedList<MovieGetModel> GetAll(int page,DateTime? from = null, DateTime? to = null);
        /// <summary>
        /// Gets a movie with a given id 
        /// </summary>
        /// <param name="id"> the movie id we are looking for </param>
        /// <returns> returns the movie object</returns>
        Movie GetById(int id);
        /// <summary>
        /// Adds a new movie to the database
        /// </summary>
        /// <param name="movie">The movie to be added </param>
        /// <returns></returns>
        Movie Create(MoviePostModel movie);
        /// <summary>
        /// Updates a movie and if it doesn`t find the movie with the give id it insert a new movie
        /// </summary>
        /// <param name="id">the id of the movie to be updated</param>
        /// <param name="movie">the new data </param>
        /// <returns></returns>
        Movie Upsert(int id, Movie movie);
        /// <summary>
        /// Deletes a movie
        /// </summary>
        /// <param name="id">The movie id to be deleted </param>
        /// <returns></returns>
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
            var existing = context.Movies.Include(f => f.Comments).FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Movies.Remove(existing);
            context.SaveChanges();

            return existing;
        }

        public PaginatedList<MovieGetModel> GetAll(int page,DateTime? from = null, DateTime? to = null)
        {
            IQueryable<Movie> result = context
                  .Movies
                  .OrderBy(m => m.Id)
                  .Include(m => m.Comments);
            PaginatedList<MovieGetModel> paginatedResult = new PaginatedList<MovieGetModel>();
            paginatedResult.CurrentPage = page;

            if (from != null)
            {
                result = result.Where(f => f.DateAdded >= from);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }
            paginatedResult.NumberOfPages = (result.Count() - 1) / PaginatedList<MovieGetModel>.EntriesPerPage + 1;
            result = result
                .Skip((page - 1) * PaginatedList<MovieGetModel>.EntriesPerPage)
                .Take(PaginatedList<MovieGetModel>.EntriesPerPage);
            paginatedResult.Entries = result.Select(f => MovieGetModel.FromMovie(f)).ToList();

            return paginatedResult;


            //IQueryable<Movie> result = context
            //    .Movies
            //    .Include(f => f.Comments);
            //if (from == null && to == null)
            //{
            //    return result.Select(f => MovieGetModel.FromMovie(f));
            //}
            //if (from != null)
            //{
            //    result = result.Where(f => f.DateAdded >= from);
            //}
            //if (to != null)
            //{
            //    result = result.Where(f => f.DateAdded <= to);
            //}
            //result = result.OrderBy(x => x.YearRelease);
            //return result.Select(f => MovieGetModel.FromMovie(f));
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
