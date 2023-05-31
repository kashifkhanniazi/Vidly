using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using Vidly.Models.DbModels;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        public CustomerController(DataContext dataContext)
        {
            _context= dataContext;
        }
        public IActionResult Index()
        {
            List<Customer> customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.FirstOrDefault(Id => Id.Id == id);
            return View(customer);
        }
    }
}
