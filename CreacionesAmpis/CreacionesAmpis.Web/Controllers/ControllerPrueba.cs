using CreacionesAmpis.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CreacionesAmpis.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPrueba: ControllerBase
    {
        private readonly RepositoryPrueba _repo;

        public ControllerPrueba(IDbConnection db)
        {
            _repo = new RepositoryPrueba(db);
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
