using SIS.Application.DTOs.AuthDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<SuccessfulLoginDto?> AuthenticateAsync(LoginDto loginDto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
