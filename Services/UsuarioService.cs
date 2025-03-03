using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BibliotecaContext _context;

        public UsuarioService(BibliotecaContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }
        
        public void Add(Usuario usuario)
        {
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
        public void Update(Usuario usuario)
        {
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
        
        public Usuario GetByUserNameAndPassword(string userName, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.UserName == userName);
            if (usuario != null && BCrypt.Net.BCrypt.Verify(password, usuario.Password))
            {
                return usuario;
            }
            return null;
        }
    }
}