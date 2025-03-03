using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using biblioteca.Services;
using System.Collections.Generic;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _service;

        public RolesController(IRolService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rol>> GetRoles()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Rol> GetRol(int id)
        {
            var rol = _service.GetById(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPost]
        public ActionResult<Rol> PostRol(Rol rol)
        {
            _service.Add(rol);
            return CreatedAtAction(nameof(GetRol), new { id = rol.PkRol }, rol);
        }

        [HttpPut("{id}")]
        public IActionResult PutRol(int id, Rol rol)
        {
            if (id != rol.PkRol)
            {
                return BadRequest();
            }
            _service.Update(rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRol(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}