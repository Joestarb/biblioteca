using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using biblioteca.Services;
using System.Collections.Generic;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _service;

        public AutoresController(IAutorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> GetAutores()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Autor> GetAutor(int id)
        {
            var autor = _service.GetById(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPost]
        public ActionResult<Autor> PostAutor(Autor autor)
        {
            _service.Add(autor);
            return CreatedAtAction(nameof(GetAutor), new { id = autor.PkAutor }, autor);
        }

        [HttpPut("{id}")]
        public IActionResult PutAutor(int id, Autor autor)
        {
            if (id != autor.PkAutor)
            {
                return BadRequest();
            }
            _service.Update(autor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAutor(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}