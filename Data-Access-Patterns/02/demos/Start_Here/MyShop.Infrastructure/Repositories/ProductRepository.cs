using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShoppingContext _context) : base(_context) { }
        public override Product Update(Product entity)
        {
            //var productFromDb = Get(entity.ProductId);
            var productFromDb = context.Products.Single(p => p.ProductId == entity.ProductId);

            productFromDb.Name = entity.Name;
            productFromDb.Price = entity.Price;

            return base.Update(productFromDb);
        }
    }
}
