using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Services
{
    public class EditorialService : IEditorialService
    {
        private readonly BibliotecaContext _context;

        public EditorialService(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Editorial> GetAll()
        {
            return _context.Editoriales.ToList();
        }

        public Editorial GetById(int id)
        {
            return _context.Editoriales.Find(id);
        }

        public void Add(Editorial editorial)
        {
            _context.Editoriales.Add(editorial);
            _context.SaveChanges();
        }

        public void Update(Editorial editorial)
        {
            _context.Entry(editorial).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var editorial = _context.Editoriales.Find(id);
            if (editorial != null)
            {
                _context.Editoriales.Remove(editorial);
                _context.SaveChanges();
            }
        }
    }
}