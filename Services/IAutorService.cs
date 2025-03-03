using biblioteca.Models;
using System.Collections.Generic;

namespace biblioteca.Services
{
    public interface IAutorService
    {
        IEnumerable<Autor> GetAll();
        Autor GetById(int id);
        void Add(Autor autor);
        void Update(Autor autor);
        void Delete(int id);
    }
}