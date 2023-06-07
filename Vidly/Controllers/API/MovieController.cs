using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Vidly.Models;
using Vidly.Models.DbModels;
using System.Linq;
using AutoMapper;
using Vidly.Dtos;
using System.Collections.Generic;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MovieController(DataContext context,IMapper mapper) {
            _context= context;
            _mapper= mapper;
        }
        //get all movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(_mapper.Map<Movie, MovieDto>);
        }
        //get movie by Id
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Movie,MovieDto>(movie));
        }
        //create movie
        [HttpPost]
        public IActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = _mapper.Map<MovieDto,Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Ok(movieDto);
        }
        //update Movie
        [HttpPut]
        public IActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = _context.Movies.FirstOrDefault(c => c.Id== id);
            if (movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieDto, movie);
            _context.SaveChanges();
            return Ok(movieDto);
        }
        [HttpDelete]
        //delete movie by id
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id== id);
            if(movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
