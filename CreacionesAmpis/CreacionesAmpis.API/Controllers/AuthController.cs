using CreacionesAmpis.Application.DTOs.Get;
using CreacionesAmpis.Application.DTOs.Set;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace CreacionesAmpis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthInterface _authInterface;
        public AuthController(IAuthInterface authInterface)
        {
            _authInterface = authInterface;

        }


        [HttpPost("[action]")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            try
            {
                var token = await _authInterface.LoginAsync(loginRequest);

                if (token is null)
                {
                    return Unauthorized();
                }
                return Ok(new LoginResponse(token)); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var response = await _authInterface.ResetPassword(resetPassword);

                if (!response)
                    return NotFound("No existe una cuenta asociada a su correo.");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
