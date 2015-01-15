using Pjatk.Pab.Books.DAL.Repositories;
using Pjatk.Pab.Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatk.Pab.Books.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DomainContext _context = new DomainContext();
        private IRepository<Book> _bookRepository;
        private IRepository<Author> _authorRepository;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                if (this._bookRepository==null)
                {
                    this._bookRepository = new Repository<Book>(_context);
                };
                return this._bookRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                if (this._authorRepository==null)
                {
                    this._authorRepository = new Repository<Author>(_context);
                };
                return this._authorRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
