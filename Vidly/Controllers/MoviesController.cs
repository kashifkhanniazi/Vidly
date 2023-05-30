using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using Vidly.Models.DbModels;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public IActionResult Random()
        {
            List<Movie> movie = new List<Movie> {
                new Movie { Name = "Shrik!" },
                new Movie { Name = "Don" }
            };
            return View(movie);
        }
    }
}
