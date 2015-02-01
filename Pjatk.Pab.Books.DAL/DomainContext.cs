using System.Data.Entity;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.DAL
{
    public class DomainContext : DbContext
    {
        public DomainContext() : base("BooksContext") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
