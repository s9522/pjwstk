using System.Collections.Generic;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.BLL.Interfaces
{
    public interface IAuthors
    {
        #region simple CRUD operations
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void RemoveAuthor(Author author);
        void RemoveAuthor(int id);
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        #endregion
    }
}
