using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vidly.Models.DbModels;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            List<Customer> customer = new List<Customer>
            {
                new Customer { Name = "Ali" },
                new Customer { Name = "Hasan" },
                new Customer { Name = "ALi" },
                new Customer { Name = "Faraz" }
            };
            RandomMovieVM vm = new RandomMovieVM
            {
                Customers = customer
            };
            return View(vm);
        }
    }
}
