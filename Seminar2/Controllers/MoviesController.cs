
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Seminar2.Model;
using System;
using Seminar2.Services;
using Seminar2.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
        public PaginatedList<MovieGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to, [FromQuery]int page = 1)
        {
            page = Math.Max(page, 1);
            return service.GetAll(page,from, to);

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        [HttpPost]
        public void Post([FromBody] MoviePostModel movie)
        {

            service.Create(movie);
        }

        /// <summary>
        /// edit movie
        /// </summary>
        /// <param name="id">movie id to be edited</param>
        /// <param name="movie"> movie edit</param>
        /// <returns></returns>
        // Put: Movies/Edit/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
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
        // Delete: Movies/Delete/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
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

    }
}
