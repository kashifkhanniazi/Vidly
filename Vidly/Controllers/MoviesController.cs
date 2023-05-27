using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        [Route("movies/random")]
        public IActionResult Random()
        {
            Movie movie= new Movie() {Name="Shrik!"};
            return View(movie);
        }
        [Route("movies/Index/{pageIndex:regex(\\d{{4}})}/{SortBy}")]
        public IActionResult Index(int? PageIndex, string SortBy) {
            if(!PageIndex.HasValue)
            {
                PageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(SortBy))
            {
                SortBy = "Name";
            }
            return Content(string.Format("PageIndex={0} SortBy={1}",PageIndex,SortBy));
        }
    }
}
