using CreacionesAmpis.Application.DTOs.Get;
using CreacionesAmpis.Application.DTOs.Set;
using CreacionesAmpis.Application.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CreacionesAmpis.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnection _db;

        public AuthRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<User?> GetByEmailAsync(string email, string password)
        {
            return await _db.QueryFirstOrDefaultAsync<User>(
               "SELECT * " +
               "FROM tbl_Usuarios WHERE tbl_Usuarios.Email = @Email " +
               "AND tbl_Usuarios.Password = @Password",
               new { Email = email, Password = password}
            );
        }

        public async Task<bool> UpdatePassword(ResetPassword resetPassword)
        {
            var rowsAffected = await _db.ExecuteAsync(
                "UPDATE tbl_Usuarios " +
                "SET Password = @NewPassword " +
                "WHERE tbl_Usuarios.Email = @Email",
                new { NewPassword = resetPassword.NewPassword, Email = resetPassword.Email }
                );

            return rowsAffected > 0;
        }

    }
}
