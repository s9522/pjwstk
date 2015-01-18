using Pjatk.Pab.Books.BLL.Interfaces;
using Pjatk.Pab.Books.DAL.Repositories;
using Pjatk.Pab.Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatk.Pab.Books.BLL.Facades
{
    public class AuthorsFacade : IAuthors
    {
        private IUnitOfWork _unitOfWork;

        public AuthorsFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region IAuthors members
        public void CreateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Add(author);
            _unitOfWork.Save();
        }

        public void UpdateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.Save();
        }

        public void RemoveAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Delete(author);
            _unitOfWork.Save();
        }

        public void RemoveAuthor(int id)
        {
            Author author = _unitOfWork.AuthorRepository.FindById(id);
            _unitOfWork.AuthorRepository.Delete(author);
            _unitOfWork.Save();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _unitOfWork.AuthorRepository.FindAll();
        }

        public Author GetAuthorById(int id)
        {
            return _unitOfWork.AuthorRepository.FindById(id);
        }

        #endregion

    }
}
