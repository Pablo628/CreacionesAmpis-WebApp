using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreacionesAmpis.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet("perfil")]
        public IActionResult Perfil()
        {
            return Ok("Solo usuarios autenticados pueden ver esto");
        }
    }
}
