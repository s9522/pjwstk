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
        private DomainContext _context;
        private Repository<Book> _bookRepository;
        private Repository<Author> _authorRepository;

        public UnitOfWork()
        {
            _context = new DomainContext();
        }

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
                    this._bookRepository = new Repository<Book>(this._context);
                }
                return this._bookRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                if (this._authorRepository==null)
                {
                    this._authorRepository = new Repository<Author>(this._context);
                }
                return this._authorRepository;                
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
