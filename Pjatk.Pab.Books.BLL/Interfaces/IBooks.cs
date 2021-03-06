﻿using Pjatk.Pab.Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatk.Pab.Books.BLL.Interfaces
{
    public interface IBooks
    {
        #region simple CRUD operations
        void UpdateBook(Book book);
        void RemoveBook(Book book);
        void RemoveBook(int id);
        Book GetBookById(int id);
        Book GetBookByIsbn(string isbn);
        void CreateBook(Book book);
        IEnumerable<Book> GetAllBooks();
        #endregion



    }
}
