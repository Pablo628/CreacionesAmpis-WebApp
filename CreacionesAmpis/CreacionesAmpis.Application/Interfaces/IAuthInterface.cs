using CreacionesAmpis.Application.DTOs.Get;
using CreacionesAmpis.Application.DTOs.Set;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreacionesAmpis.Application.Interfaces
{
    public interface IAuthInterface
    {
        Task<string?> LoginAsync(LoginRequest request);
        Task<bool> ResetPassword(ResetPassword resetPassword);
    }
}
