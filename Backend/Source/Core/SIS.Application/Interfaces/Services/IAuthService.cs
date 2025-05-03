using SIS.Application.DTOs.AuthDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<SuccessfulLoginDto?> AuthenticateAsync(LoginDto loginDto);
        Task<bool> ResetPasswordAsync(ResetPassword resetPasswordDto);
        Task<string> GetResetTokenAsync(string schoolMail);
        Task<bool> CheckPasswordByIdAsync(string userId, string password);
    }
}
