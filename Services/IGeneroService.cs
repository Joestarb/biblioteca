using biblioteca.Models;
using System.Collections.Generic;

namespace biblioteca.Services
{
    public interface IGeneroService
    {
        IEnumerable<Genero> GetAll();
        Genero GetById(int id);
        void Add(Genero genero);
        void Update(Genero genero);
        void Delete(int id);
    }
}