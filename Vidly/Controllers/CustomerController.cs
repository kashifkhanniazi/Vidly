using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Vidly.Models;
using Vidly.Models.DbModels;
using Vidly.Models.VMModels;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        public CustomerController(DataContext dataContext)
        {
            _context = dataContext;
        }
        public IActionResult Index()
        {
            List<Customer> customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(Id => Id.Id == id);
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                CustomerFormVM vm = new CustomerFormVM() {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", vm);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var update = _context.Customers.Single(c => c.Id == customer.Id);
                update.Name = customer.Name;
                update.Birthdate = customer.Birthdate;
                update.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                update.MembershipTypeId = customer.MembershipTypeId;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult New()
        {
            var MembershipType = _context.MembershipTypes.ToList();
            CustomerFormVM vm = new CustomerFormVM()
            {
                Customer = new Customer(),
                MembershipTypes = MembershipType
            };
            return View("CustomerForm",vm);
        }
        public IActionResult Edit(int id) {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            CustomerFormVM vm = new CustomerFormVM()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", vm);
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
