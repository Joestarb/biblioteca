using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public AutoresController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> GetAutores()
        {
            return _context.Autores.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Autor> GetAutor(int id)
        {
            var autor = _context.Autores.Find(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public ActionResult<Autor> PostAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAutor), new { id = autor.PkAutor }, autor);
        }

        [HttpPut("{id}")]
        public IActionResult PutAutor(int id, Autor autor)
        {
            if (id != autor.PkAutor)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAutor(int id)
        {
            var autor = _context.Autores.Find(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            _context.SaveChanges();

            return NoContent();
        }
    }
}