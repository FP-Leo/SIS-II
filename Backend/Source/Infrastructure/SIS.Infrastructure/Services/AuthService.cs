using SIS.Application.DTOs.AuthDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Application.Mappers;
using SIS.Domain.Exceptions.Database;

namespace SIS.Infrastructure.Services
{
    public class AuthService(IUserService userService, ITokenService tokenService) : IAuthService
    {
        private readonly IUserService _userService = userService;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<SuccessfulLoginDto?> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await _userService.GetUserByUsernameAsync(loginDto.Username);
            // Don't throw an exception if the user is not found or password is not correct, just return null. Avoids leaking information about whether the user exists.
            if (user == null) return null;

            var isValidPassword = await _userService.CheckPasswordAsync(user, loginDto.Password);
            if (!isValidPassword) return null;

            var userRoles = await _userService.GetUserRolesAsync(user);

            var token = await _tokenService.CreateToken(user);

            return new SuccessfulLoginDto
            {
                UserData = user.ToUserGetDto(),
                Role = userRoles,
                Token = token
            };
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            // Can throw an exception if the user is not found, as this is a valid case for a reset password operation.
            var user = await _userService.GetUserByIdAsync(resetPasswordDto.UserId) ?? throw new EntityNotFoundException(resetPasswordDto.UserId);
            var result = await _userService.ResetPasswordAsync(user, resetPasswordDto.NewPassword);

            return result;
        }
    }
}
