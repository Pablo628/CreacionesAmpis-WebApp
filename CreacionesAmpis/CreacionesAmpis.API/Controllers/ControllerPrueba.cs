using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreacionesAmpis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPrueba : ControllerBase
    {
        private readonly IServicePrueba _service;

        public ControllerPrueba(IServicePrueba service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null) return NotFound(new { message = $"No se encontró el registro con Id {id}." });
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateModelPruebaDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateModelPruebaDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound(new { message = $"No se encontró el registro con Id {id}." });
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(new { message = $"No se encontró el registro con Id {id}." });
            return NoContent();
        }
    }
}
