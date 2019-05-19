
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seminar2.Model;
using System;
using Seminar2.Services;
using Seminar2.ViewModel;
using Microsoft.AspNetCore.Http;

namespace Seminar2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService service;

        public MoviesController(
            IMovieService service)
        {
            this.service = service;
        }
        /// <summary>
        /// gets all movies
        /// </summary>
        /// <param name="from"> optional, filter, date from</param>
        /// <param name="to">optional , filter, date to</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<MovieGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            return service.GetAll(from, to);

        }



        /// <summary>
        /// gets a specific movie
        /// </summary>
        /// <param name="id">movie id</param>
        /// <returns></returns>
        // GET:api/Movies/Details/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = service.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }






        /// <summary>
        /// add movie
        /// </summary>
        /// <param name="movie">movie to add</param>
        // GET: Movies/Create
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] MoviePostModel movie)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            service.Create(movie);
        }
        /// <summary>
        /// edit movie
        /// </summary>
        /// <param name="id">movie id to be edited</param>
        /// <param name="movie"> movie edit</param>
        /// <returns></returns>
        // GET: Movies/Edit/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            service.Upsert(id, movie);
            return Ok(movie);
        }


        /// <summary>
        /// delete a movie
        /// </summary>
        /// <param name="id"> movie id to be deleted</param>
        /// <returns></returns>
        // GET: Movies/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = service.Delete(id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok();
        }



        //private bool MovieExists(int id)
        //{
        //    return _context.Movies.Any(e => e.Id == id);
        //}
    }
}
