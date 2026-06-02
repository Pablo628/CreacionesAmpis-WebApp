using CreacionesAmpis.Application.DTOs.Get;
using CreacionesAmpis.Application.DTOs.Set;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreacionesAmpis.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetByEmailAsync(string email, string password);
        Task<bool> UpdatePassword(ResetPassword resetPassword);
    }
}
