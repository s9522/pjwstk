using Pjatk.Pab.Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatk.Pab.Books.BLL.Facades
{
    public interface IBooks
    { 
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void RemoveBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
    }
}
