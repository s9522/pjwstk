using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Pjatk.Pab.Books.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DomainContext context;
        internal DbSet<T> dbSet;

        public Repository(DomainContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Find(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> FindAll()
        {
            return dbSet;
        }

    }
}
