using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public RolesController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rol>> GetRoles()
        {
            return _context.Roles.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Rol> GetRol(int id)
        {
            var rol = _context.Roles.Find(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        [HttpPost]
        public ActionResult<Rol> PostRol(Rol rol)
        {
            _context.Roles.Add(rol);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRol), new { id = rol.PkRol }, rol);
        }

        [HttpPut("{id}")]
        public IActionResult PutRol(int id, Rol rol)
        {
            if (id != rol.PkRol)
            {
                return BadRequest();
            }

            _context.Entry(rol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRol(int id)
        {
            var rol = _context.Roles.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(rol);
            _context.SaveChanges();

            return NoContent();
        }
    }
}