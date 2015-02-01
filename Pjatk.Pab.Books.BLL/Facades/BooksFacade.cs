using System;
using System.Collections.Generic;
using Pjatk.Pab.Books.BLL.Interfaces;
using Pjatk.Pab.Books.DAL.Repositories;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.BLL.Facades
{
    public class BooksFacade : IBooks
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IBooks members
        public void UpdateBook(Book book)
        {
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Save();
        }

        public void RemoveBook(Book book)
        {
            _unitOfWork.BookRepository.Delete(book);
            _unitOfWork.Save();
        }

        public void RemoveBook(int id)
        {
            Book book = _unitOfWork.BookRepository.FindById(id);
            _unitOfWork.BookRepository.Delete(book);
            _unitOfWork.Save();
        }

        public Book GetBookById(int id)
        {
            return _unitOfWork.BookRepository.FindById(id);
        }

        public Book GetBookByIsbn(string isbn)
        {
            throw new NotImplementedException();
        }

        public void CreateBook(Book book)
        {
            _unitOfWork.BookRepository.Add(book);
            foreach (var item in book.Authors)
            {
                item.Books.Add(book);
            }
            _unitOfWork.Save();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _unitOfWork.BookRepository.FindAll();
        }

        #endregion
    }
}
