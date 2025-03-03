using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Services
{
    public class LibroService : ILibroService
    {
        private readonly BibliotecaContext _context;

        public LibroService(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro GetById(int id)
        {
            return _context.Libros.Find(id);
        }

        public void Add(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void Update(Libro libro)
        {
            _context.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                _context.SaveChanges();
            }
        }
    }
}