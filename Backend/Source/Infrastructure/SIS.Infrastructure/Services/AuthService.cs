using Microsoft.AspNetCore.Identity;
using SIS.Application.DTOs.AuthDTOs;
using SIS.Application.Interfaces.Services;

namespace SIS.Infrastructure.Services
{
    public class AuthService(IUserService userService, ITokenService tokenService) : IAuthService
    {
        private readonly IUserService _userService = userService;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<string?> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await _userService.GetUserByUsernameAsync(loginDto.Username);
            if (user == null) return null;

            var isValidPassword = await _userService.CheckPasswordAsync(user, loginDto.Password);
            if (!isValidPassword) return null;

            return _tokenService.CreateToken(user);
        }
    }
}
