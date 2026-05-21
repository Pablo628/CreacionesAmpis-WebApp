using CreacionesAmpis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreacionesAmpis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPrueba : ControllerBase
    {
        private readonly IModelPruebaRepository _repo;

        public ControllerPrueba(IModelPruebaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _repo.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repo.GetByIdAsync(id);
            if (usuario is null) return NotFound();
            return Ok(usuario);
        }
    }
}
