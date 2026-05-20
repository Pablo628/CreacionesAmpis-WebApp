using CreacionesAmpis.Web.Models;
using CreacionesAmpis.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreacionesAmpis.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _auth.LoginAsync(dto);

            if (token == null)
                return Unauthorized("Credenciales incorrectas");

            return Ok(new { token });
        }
    }
}
