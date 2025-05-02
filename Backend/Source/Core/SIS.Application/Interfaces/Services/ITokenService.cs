using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
