using System.Collections.Generic;
using Pjatk.Pab.Books.BLL.Interfaces;
using Pjatk.Pab.Books.DAL.Repositories;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.BLL.Facades
{
    public class ReadersFacade : IReaders
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReadersFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region IReaders members
        public void CreateReader(Reader reader)
        {
            _unitOfWork.ReaderRepository.Add(reader);
            _unitOfWork.Save();
        }

        public void UpdateReader(Reader reader)
        {
            _unitOfWork.ReaderRepository.Update(reader);
            _unitOfWork.Save();
        }

        public void RemoveReader(Reader reader)
        {
            _unitOfWork.ReaderRepository.Delete(reader);
            _unitOfWork.Save();
        }

        public void RemoveReader(int id)
        {
            Reader reader = _unitOfWork.ReaderRepository.FindById(id);
            _unitOfWork.ReaderRepository.Delete(reader);
            _unitOfWork.Save();
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return _unitOfWork.ReaderRepository.FindAll();
        }

        public Reader GetReaderById(int id)
        {
            return _unitOfWork.ReaderRepository.FindById(id);
        }

        #endregion

    }
}
