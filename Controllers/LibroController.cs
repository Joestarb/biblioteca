using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using biblioteca.Services;
using System.Collections.Generic;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _service;

        public LibrosController(ILibroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> GetLibros()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> GetLibro(int id)
        {
            var libro = _service.GetById(id);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        public ActionResult<Libro> PostLibro(Libro libro)
        {
            _service.Add(libro);
            return CreatedAtAction(nameof(GetLibro), new { id = libro.PkLibro }, libro);
        }

        [HttpPut("{id}")]
        public IActionResult PutLibro(int id, Libro libro)
        {
            if (id != libro.PkLibro)
            {
                return BadRequest();
            }
            _service.Update(libro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibro(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}