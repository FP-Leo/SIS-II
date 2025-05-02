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
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config, UserManager<User> userManager)
        {
            _userManager = userManager;
            _config = config;

            string signingKey = _config["JWT:SigningKey"]
                ?? throw new InvalidOperationException("JWT:SigningKey is not configured.");

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        }
        public async Task<string> CreateToken(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                throw new ArgumentException("UserName cannot be null or empty.", nameof(user));
            }

            var roles = await _userManager.GetRolesAsync(user);
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

            var daysString = _config["JWT:TokenLifetimeDays"];
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

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);

            }
            catch (Exception ex)
            {
                throw new TokenCreationFailedException("Failed to create token.", ex);
            }
        }
    }
}

