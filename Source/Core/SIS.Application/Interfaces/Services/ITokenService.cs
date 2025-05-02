using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
