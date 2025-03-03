using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using biblioteca.Services;
using System.Collections.Generic;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _service.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            _service.Add(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.PkUsuario }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.PkUsuario)
            {
                return BadRequest();
            }
            _service.Update(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}