using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Services
{
    public class RolService : IRolService
    {
        private readonly BibliotecaContext _context;

        public RolService(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Rol GetById(int id)
        {
            return _context.Roles.Find(id);
        }

        public void Add(Rol rol)
        {
            _context.Roles.Add(rol);
            _context.SaveChanges();
        }

        public void Update(Rol rol)
        {
            _context.Entry(rol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                _context.SaveChanges();
            }
        }
    }
}