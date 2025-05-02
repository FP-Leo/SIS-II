using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Application.Mappers;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Database;

namespace SIS.Infrastructure.Services
{
    public class UserService(UserManager<User> userManager, ITokenService tokenService) : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<User?> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<User?> GetUserByUsernameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<User?> GetUserBySchoolMailAsync(string schoolMail)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.SchoolMail == schoolMail);
            return user;
        }

        public async Task<string> RegisterUserAsync(UserCreateDto request)
        {
            var user = request.ToUser();

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new ApplicationException($"User creation failed: {errors}");
            }

            var roleResult = await _userManager.AddToRoleAsync(user, request.Role);
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                var errors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                throw new ApplicationException($"Role assignment failed: {errors}, rolling back...");
            }

            var token = _tokenService.CreateToken(user);

            return token;
        }

        public async Task UpdateUserAsync(User user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                // You can aggregate the errors into a single message, or handle them individually
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new EntityUpdateFailedException($"Failed to update user {user.Id}: {errors}");
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new EntityDeleteFailedException($"Failed to delete user {user.Id}: {errors}");
            }
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }
    }
}
