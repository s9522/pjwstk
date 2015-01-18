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
            for (int i = 1; i <= 25; i++)
            {
                Author a = new Author { DateOfBirth = DateTime.Today, FirstName = "Imię"+i, LastName = "Nazwisko" +i };
                Book b = new Book { Isbn = "0-306-406" + i.ToString(), PagesCount = 100+i, PublishDate = DateTime.Today, Publisher = "Wydawnictwo "+i, Title = "Tytuł " + i, Subtitle = "Podtytuł" + i, EditionNumber = i };
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
}
