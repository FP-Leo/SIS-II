using SIS.Application.DTOs.AuthDTOs;

namespace SIS.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(LoginDto loginDto);
    }
}
