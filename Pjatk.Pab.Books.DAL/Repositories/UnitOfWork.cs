using System;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DomainContext _context;
        private Repository<Book> _bookRepository;
        private Repository<Author> _authorRepository;
        private Repository<BookRental> _bookRentalRepository;
        private Repository<Reader> _readerRepository;

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

        public IRepository<Reader> ReaderRepository
        {
            get
            {
                if (this._readerRepository == null)
                {
                    this._readerRepository = new Repository<Reader>(this._context);
                }
                return this._readerRepository;
            }
        }

        public IRepository<BookRental> BookRentalRepository
        {
            get
            {
                if (this._bookRentalRepository == null)
                {
                    this._bookRentalRepository = new Repository<BookRental>(this._context);
                }
                return this._bookRentalRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
