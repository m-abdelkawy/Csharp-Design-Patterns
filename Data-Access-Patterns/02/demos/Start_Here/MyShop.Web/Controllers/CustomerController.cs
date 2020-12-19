using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> customerRepo;

        public CustomerController(IRepository<Customer> _customerRepo)
        {
            customerRepo = _customerRepo;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = customerRepo.GetAll();

                return View(customers);
            }
            else
            {
                var customer = customerRepo.Get(id);

                return View(new[] { customer });
            }
        }
    }
}
