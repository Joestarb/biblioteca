using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly BibliotecaContext _context;

        public GeneroService(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Genero> GetAll()
        {
            return _context.Generos.ToList();
        }

        public Genero GetById(int id)
        {
            return _context.Generos.Find(id);
        }

        public void Add(Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
        }

        public void Update(Genero genero)
        {
            _context.Entry(genero).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var genero = _context.Generos.Find(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
                _context.SaveChanges();
            }
        }
    }
}