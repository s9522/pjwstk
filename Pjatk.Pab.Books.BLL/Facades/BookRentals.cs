using System.Collections.Generic;
using Pjatk.Pab.Books.BLL.Interfaces;
using Pjatk.Pab.Books.DAL.Repositories;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.BLL.Facades
{
    public class BookRentalsFacade : IBookRentals
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookRentalsFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region IBookRentals members
        public void CreateBookRental(BookRental bookRental)
        {
            _unitOfWork.BookRentalRepository.Add(bookRental);
            _unitOfWork.Save();
        }

        public void UpdateBookRental(BookRental bookRental)
        {
            _unitOfWork.BookRentalRepository.Update(bookRental);
            _unitOfWork.Save();
        }

        public void RemoveBookRental(BookRental bookRental)
        {
            _unitOfWork.BookRentalRepository.Delete(bookRental);
            _unitOfWork.Save();
        }

        public void RemoveBookRental(int id)
        {
            BookRental bookRental = _unitOfWork.BookRentalRepository.FindById(id);
            _unitOfWork.BookRentalRepository.Delete(bookRental);
            _unitOfWork.Save();
        }

        public IEnumerable<BookRental> GetAllBookRentals()
        {
            return _unitOfWork.BookRentalRepository.FindAll();
        }

        public BookRental GetBookRentalById(int id)
        {
            return _unitOfWork.BookRentalRepository.FindById(id);
        }

        #endregion

    }
}
