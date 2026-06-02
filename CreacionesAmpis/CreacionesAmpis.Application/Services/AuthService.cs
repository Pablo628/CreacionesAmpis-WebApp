using CreacionesAmpis.Application.DTOs.Get;
using CreacionesAmpis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using CreacionesAmpis.Application.DTOs.Set;

namespace CreacionesAmpis.Application.Services
{
    public class AuthService : IAuthInterface
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<string?> LoginAsync(LoginRequest request)
        {
            var user = await _authRepository.GetByEmailAsync(request.Email, request.Password);

            if (user is null) return null;

            return GenerateToken(user);

        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("CreacionesAmpis_SecretKey_2026!@#$")
            );

            var credentials = new SigningCredentials(
                secretKey,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: "CreacionesAmpis.server",
                audience: "localhost:4200",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                return await _authRepository.UpdatePassword(resetPassword);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
