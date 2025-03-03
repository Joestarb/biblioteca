using Microsoft.AspNetCore.Mvc;
using biblioteca.Models;
using biblioteca.Services;
using System.Collections.Generic;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly IEditorialService _service;

        public EditorialesController(IEditorialService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Editorial>> GetEditoriales()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Editorial> GetEditorial(int id)
        {
            var editorial = _service.GetById(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return Ok(editorial);
        }

        [HttpPost]
        public ActionResult<Editorial> PostEditorial(Editorial editorial)
        {
            _service.Add(editorial);
            return CreatedAtAction(nameof(GetEditorial), new { id = editorial.PkEditorial }, editorial);
        }

        [HttpPut("{id}")]
        public IActionResult PutEditorial(int id, Editorial editorial)
        {
            if (id != editorial.PkEditorial)
            {
                return BadRequest();
            }
            _service.Update(editorial);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEditorial(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}