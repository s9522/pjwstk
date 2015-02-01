using System;
using System.Collections.Generic;
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
                Book b = new Book
                {
                    Isbn = "0-306-406" + i.ToString(),
                    PagesCount = 100 + i,
                    PublishDate = DateTime.Today,
                    Publisher = "Wydawnictwo " + i,
                    Title = "Tytuł " + i,
                    Subtitle = "Podtytuł" + i,
                    EditionNumber = i,
                    Authors = new List<Author> {a}
                };
                a.Books = new List<Book> {b};

                context.Authors.Add(a);
                context.Books.Add(b);
                Reader r = new Reader {FirstName = "Czytelnik", LastName = "nr " + i};
                context.Readers.Add(r);
                BookRental br = new BookRental
                {
                    Books = new List<Book>{b},
                    Reader = r,
                    DateFrom = new DateTime(2015, 1, i),
                    DateTo = new DateTime(2015, 2, i)
                };
                context.BookRentals.Add(br);
                context.SaveChanges();
            }
        }
    }
}
