using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pjatk.Pab.Books.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {        
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> FindAll();
        T FindById(int Id);
        IEnumerable<T> Find(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");            
    }
}
