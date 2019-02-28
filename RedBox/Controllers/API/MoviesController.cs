using AutoMapper;
using RedBox.Dtos;
using RedBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedBox.Controllers.API
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/movies
        public IHttpActionResult GetMovies()
        {
             return Ok(_context.Movies.ToList().Select(Mapper.Map<MovieModel, MovieDTO>));
        }
        //GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null) return NotFound();

            return Ok(Mapper.Map<MovieModel, MovieDTO>(movie));
        }
        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movie = Mapper.Map<MovieDTO,MovieModel>(movieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.ID = movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + movieDTO.ID), movieDTO);
        }
        // PUT api/movies
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movieInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDTO,movieInDb);
            _context.SaveChanges();
        }
        //DELETE api/movies/id
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movieInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
