using biblioteca.Models;
using System.Collections.Generic;

namespace biblioteca.Services
{
    public interface IRolService
    {
        IEnumerable<Rol> GetAll();
        Rol GetById(int id);
        void Add(Rol rol);
        void Update(Rol rol);
        void Delete(int id);
    }
}