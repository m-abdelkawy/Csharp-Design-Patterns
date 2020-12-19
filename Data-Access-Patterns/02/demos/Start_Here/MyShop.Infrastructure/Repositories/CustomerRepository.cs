using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext _context) : base(_context) { }

        public override Customer Update(Customer entity)
        {
            var customerFromDb = context.Customers.Single(c => c.CustomerId == entity.CustomerId);

            customerFromDb.Name = entity.Name;
            customerFromDb.City = entity.City;
            customerFromDb.PostalCode = entity.PostalCode;
            customerFromDb.ShippingAddress = entity.ShippingAddress;
            customerFromDb.Country = entity.Country;

            return base.Update(customerFromDb);
        }
    }
}
