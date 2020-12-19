using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShoppingContext context;
        public GenericRepository(ShoppingContext _context)
        {
            context = _context;
        }
        public virtual T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public virtual T Get(params object[] id)
        {
            return context.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public virtual T Update(T entity)
        {
            return context.Update(entity).Entity;
        }
    }
}
