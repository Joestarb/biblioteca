using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public EditorialesController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Editorial>> GetEditoriales()
        {
            return _context.Editoriales.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Editorial> GetEditorial(int id)
        {
            var editorial = _context.Editoriales.Find(id);

            if (editorial == null)
            {
                return NotFound();
            }

            return editorial;
        }

        [HttpPost]
        public ActionResult<Editorial> PostEditorial(Editorial editorial)
        {
            _context.Editoriales.Add(editorial);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEditorial), new { id = editorial.PkEditorial }, editorial);
        }

        [HttpPut("{id}")]
        public IActionResult PutEditorial(int id, Editorial editorial)
        {
            if (id != editorial.PkEditorial)
            {
                return BadRequest();
            }

            _context.Entry(editorial).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEditorial(int id)
        {
            var editorial = _context.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }

            _context.Editoriales.Remove(editorial);
            _context.SaveChanges();

            return NoContent();
        }
    }
}