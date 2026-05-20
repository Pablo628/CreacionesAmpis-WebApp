using CreacionesAmpis.Web.Models;
using CreacionesAmpis.Web.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CreacionesAmpis.Web.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly RepositoryPrueba _repo;

        public AuthService(IConfiguration config, RepositoryPrueba repo)
        {
            _config = config;
            _repo = repo;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _repo.GetByEmailAsync(dto.Email);

            if (user == null || user.Contrasena != dto.Contrasena)
                return null;

            return GenerateToken(user);
        }

        private string GenerateToken(ModelPrueba user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Rol)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
