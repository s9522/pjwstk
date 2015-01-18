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
        private IRepository<Book> _bookRepository;
        private IRepository<Author> _authorRepository;

        public UnitOfWork(DomainContext context, IRepository<Book> booksRepo, IRepository<Author> authorsRepo)
        {
            _context = context;
            _bookRepository = booksRepo;
            _authorRepository = authorsRepo;
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
                return this._bookRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                return this._authorRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
