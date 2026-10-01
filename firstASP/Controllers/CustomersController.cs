using Microsoft.AspNetCore.Mvc;
using firstASP.Data;
using firstASP.Models;

namespace firstASP.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
                return RedirectToAction("Index");

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(string id, Customer customer)
        {
            var existingCustomer = _db.Customers.Find(id);

            if (existingCustomer == null)
                return RedirectToAction("Index");

            existingCustomer.ContactName = customer.ContactName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;
            existingCustomer.City = customer.City;
            existingCustomer.State = customer.State;
            existingCustomer.ZipCode = customer.ZipCode;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var customer = _db.Customers.Find(id);

            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}