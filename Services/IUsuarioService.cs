using biblioteca.Models;
using System.Collections.Generic;

namespace biblioteca.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        Usuario GetByUserNameAndPassword(string userName, string password);

    }
}