using biblioteca.Models;
using System.Collections.Generic;

namespace biblioteca.Services
{
    public interface IEditorialService
    {
        IEnumerable<Editorial> GetAll();
        Editorial GetById(int id);
        void Add(Editorial editorial);
        void Update(Editorial editorial);
        void Delete(int id);
    }
}