using System;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> BookRepository { get; }
        IRepository<Author> AuthorRepository { get; }
        IRepository<Reader> ReaderRepository { get; }
        IRepository<BookRental> BookRentalRepository { get; }
        void Save();
    }
}
