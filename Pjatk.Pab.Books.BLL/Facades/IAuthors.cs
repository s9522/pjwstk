using Pjatk.Pab.Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatk.Pab.Books.BLL.Facades
{
    public interface IAuthors
    {
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void RemoveAuthor(Author author);
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int id);
    }
}
