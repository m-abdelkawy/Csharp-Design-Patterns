using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository:GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext _context) : base(_context) { }

        public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders
                .Include(o => o.LineItems)
                .ThenInclude(l=>l.Product)
                .Where(predicate)
                .ToList();
        }
        public override Order Update(Order entity)
        {
            var orderFromDb = context.Orders
                .Include(o=>o.LineItems)
                .ThenInclude(l=>l.Product)
                .Single(o => o.OrderId == entity.OrderId);

            orderFromDb.OrderDate = entity.OrderDate;
            orderFromDb.LineItems = entity.LineItems;

            return base.Update(orderFromDb);
        }
    }
}
