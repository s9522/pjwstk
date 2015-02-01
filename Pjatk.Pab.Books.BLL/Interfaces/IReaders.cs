using System.Collections.Generic;
using Pjatk.Pab.Books.Domain.Models;

namespace Pjatk.Pab.Books.BLL.Interfaces
{
    public interface IReaders
    {
        #region simple CRUD operations
        void CreateReader(Reader reader);
        void UpdateReader(Reader reader);
        void RemoveReader(Reader reader);
        void RemoveReader(int id);
        IEnumerable<Reader> GetAllReaders();
        Reader GetReaderById(int id);
        #endregion 
    }
}