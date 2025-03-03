using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public GenerosController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> GetGeneros()
        {
            return _context.Generos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Genero> GetGenero(int id)
        {
            var genero = _context.Generos.Find(id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public ActionResult<Genero> PostGenero(Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetGenero), new { id = genero.PkGenero }, genero);
        }

        [HttpPut("{id}")]
        public IActionResult PutGenero(int id, Genero genero)
        {
            if (id != genero.PkGenero)
            {
                return BadRequest();
            }

            _context.Entry(genero).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenero(int id)
        {
            var genero = _context.Generos.Find(id);
            if (genero == null)
            {
                return NotFound();
            }

            _context.Generos.Remove(genero);
            _context.SaveChanges();

            return NoContent();
        }
    }
}