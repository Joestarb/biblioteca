using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using biblioteca.Services;
using System.Collections.Generic;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _service;

        public GenerosController(IGeneroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> GetGeneros()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Genero> GetGenero(int id)
        {
            var genero = _service.GetById(id);
            if (genero == null)
            {
                return NotFound();
            }
            return Ok(genero);
        }

        [HttpPost]
        public ActionResult<Genero> PostGenero(Genero genero)
        {
            _service.Add(genero);
            return CreatedAtAction(nameof(GetGenero), new { id = genero.PkGenero }, genero);
        }

        [HttpPut("{id}")]
        public IActionResult PutGenero(int id, Genero genero)
        {
            if (id != genero.PkGenero)
            {
                return BadRequest();
            }
            _service.Update(genero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenero(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}