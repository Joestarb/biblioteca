using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Services
{
    public class AutorService : IAutorService
    {
        private readonly BibliotecaContext _context;

        public AutorService(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Autor> GetAll()
        {
            return _context.Autores.ToList();
        }

        public Autor GetById(int id)
        {
            return _context.Autores.Find(id);
        }

        public void Add(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }

        public void Update(Autor autor)
        {
            _context.Entry(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var autor = _context.Autores.Find(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                _context.SaveChanges();
            }
        }
    }
}