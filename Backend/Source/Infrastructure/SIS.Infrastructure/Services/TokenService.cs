using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using SIS.Domain.Entities;
using System.Security.Claims;
using System.Text;
using SIS.Application.Interfaces.Services;
using SIS.Domain.Exceptions.Services.Token;

namespace SIS.Infrastructure.Services
{
    /// <summary>
    /// Provides methods for token-related operations.
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="config">The configuration containing JWT settings.</param>
        /// <param name="userManager">The user manager for managing user entities.</param>
        /// <exception cref="InvalidOperationException">Thrown when the signing key is not configured.</exception>
        public TokenService(IConfiguration config, UserManager<User> userManager)
        {
            _userManager = userManager;
            _config = config;

            string signingKey = _config["JWT:SigningKey"]
                ?? throw new InvalidOperationException("JWT:SigningKey is not configured.");

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        }

        /// <summary>
        /// Creates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the token is created.</param>
        /// <returns>The generated JWT token as a string.</returns>
        /// <exception cref="ArgumentException">Thrown when the user's username is null or empty.</exception>
        /// <exception cref="TokenCreationFailedException">Thrown when the user has no roles assigned or token creation fails.</exception>
        public async Task<string> CreateToken(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ArgumentException("UserName cannot be null or empty.", nameof(user));
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);
            if (roles == null || roles.Count == 0)
            {
                throw new TokenCreationFailedException("User has no roles assigned.");
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id),
                new (ClaimTypes.Name, user.UserName),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            string? daysString = _config["JWT:TokenLifetimeDays"];
            if (!int.TryParse(daysString, out int days))
            {
                throw new TokenCreationFailedException("JWT:TokenLifetimeDays is not a valid integer.");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(days),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new TokenCreationFailedException("Failed to create token.", ex);
            }
        }
    }
}

