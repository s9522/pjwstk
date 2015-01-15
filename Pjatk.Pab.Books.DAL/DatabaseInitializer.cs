using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Pjatk.Pab.Books.Domain.Models;
namespace Pjatk.Pab.Books.DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DomainContext>
    {
        protected override void Seed(DomainContext context)
        {
            Author a = new Author { DateOfBirth = DateTime.Today, FirstName = "Jan", LastName = "Kowalski" };
            Book b = new Book { Isbn = "dsad1212", PagesCount = 100, PublishDate = DateTime.Today, Publisher = "WSIP", Title = "ABC", Subtitle = "Alfabet" };
            b.Authors = new List<Author>();
            b.Authors.Add(a);
            a.Books = new List<Book>();
            a.Books.Add(b);

            context.Authors.Add(a);
            context.Books.Add(b);
            context.SaveChanges();
        }
    }
}
