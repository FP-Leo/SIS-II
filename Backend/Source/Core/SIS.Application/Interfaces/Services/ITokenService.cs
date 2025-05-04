using SIS.Domain.Entities;

namespace SIS.Application.Interfaces.Services
{
    /// <summary>
    /// Provides methods for token-related operations.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Creates a token for a user.
        /// </summary>
        /// <param name="user">The user for whom the token is created.</param>
        /// <returns>The generated token.</returns>
        Task<string> CreateToken(User user);
    }
}
