using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using Vidly.Models.DbModels;
using Vidly.Models.VMModels;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly DataContext _context;
        public MoviesController(DataContext dataContext)
        {
            _context = dataContext;
        }
        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var movie = _context.Movies.Include(g => g.Genres).FirstOrDefault(c => c.Id== id);
            MovieFormVM vm = new MovieFormVM(movie) { 
                Genres= genres
            };
            return View("MovieForm",vm);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            MovieFormVM vm = new MovieFormVM()
            {
                Genres = genres
            };
            return View("MovieForm",vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                MovieFormVM vm = new MovieFormVM(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", vm);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var update = _context.Movies.Single(c => c.Id == movie.Id);
                update.Name = movie.Name;
                update.Releasedate = movie.Releasedate;
                update.GenresId = movie.GenresId;
                update.Stock = movie.Stock;
            }

            _context.SaveChanges();
            return RedirectToAction("Random","Movies");
        }
        public IActionResult Random()
        {
            List<Movie> movie = _context.Movies.Include(g => g.Genres).ToList();
            return View(movie);
        }
        public IActionResult Details(int id)
        {
            var customer = _context.Movies.Include(g => g.Genres).FirstOrDefault(Id => Id.Id == id);
            return View(customer);
        }
    }
}
