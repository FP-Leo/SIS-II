using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.AuthDTOs;
using SIS.Application.Interfaces.Services;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var successfulLogInDto = await _authService.AuthenticateAsync(loginDto);
            if (successfulLogInDto == null)
                return Unauthorized("Invalid credentials");

            return Ok(successfulLogInDto);
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out successfully. Please remove the token on the client side." });
        }

        [HttpPost("reset/password")]
        [Authorize] // adjust as needed (could be [AllowAnonymous] if done via email link, etc.)
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var isSuccessful = await _authService.ResetPasswordAsync(resetPasswordDto);
            if (!isSuccessful)
                return StatusCode(500, "Internal Server error. Unable to reset password.");

            return Ok("Password reset successful.");
        }
    }
}
