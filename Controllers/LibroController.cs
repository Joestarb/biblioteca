using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LibrosController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> GetLibros()
        {
            return _context.Libros.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> GetLibro(int id)
        {
            var libro = _context.Libros.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        [HttpPost]
        public ActionResult<Libro> PostLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetLibro), new { id = libro.PkLibro }, libro);
        }

        [HttpPut("{id}")]
        public IActionResult PutLibro(int id, Libro libro)
        {
            if (id != libro.PkLibro)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibro(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            _context.SaveChanges();

            return NoContent();
        }
    }
}