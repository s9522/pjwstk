using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
