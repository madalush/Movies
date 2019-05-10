
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seminar2.Model;
using System;

namespace Seminar2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        // GET:api/Movies/Details/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        [HttpGet("{start}/{end}")]
        public IEnumerable<Movie> GetReport(DateTime start, DateTime end)
        {
            return _context.Movies.Where(m => (m.DateAdded >= start) && (m.DateAdded <= end))
                .OrderBy(x => x.YearRelease)
                .ToList();



        }

        // GET: Movies/Create
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        // GET: Movies/Edit/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var existing = _context.Movies.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return Ok(movie);
            }
            movie.Id = id;
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return Ok(movie);
        }



        // GET: Movies/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(existing);
            _context.SaveChanges();
            return Ok();
        }



        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
