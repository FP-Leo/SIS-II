using SIS.Application.DTOs.UserDTOs;
using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(string id);
        Task<User?> GetUserByUsernameAsync(string userName);
        Task<User?> GetUserBySchoolMailAsync(string schoolMail);
        Task<string> RegisterUserAsync(UserCreateDto user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
