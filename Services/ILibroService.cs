using biblioteca.Models;
using System.Collections.Generic;

namespace biblioteca.Services
{
    public interface ILibroService
    {
        IEnumerable<Libro> GetAll();
        Libro GetById(int id);
        void Add(Libro libro);
        void Update(Libro libro);
        void Delete(int id);
    }
}