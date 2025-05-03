using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.API.Common;
using SIS.Application.DTOs.AuthDTOs;
using SIS.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading.Tasks;

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
                return Unauthorized("Invalid credentials.");

            return Ok(successfulLogInDto);
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out successfully. Please remove the token on the client side." });
        }

        [HttpPatch("password")]
        [Authorize]
        public async Task<IActionResult> SelfResetPassword([FromBody] SelfResetPasswordDto dto, [FromServices] IValidator<SelfResetPasswordDto> validator)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("User not found.");

            if (userId != dto.UserId)
                return Unauthorized("User ID mismatch.");

            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            // Maybe move this to the validation layer to be more consistent with the rest of the code?
            var isValidPassword = await _authService.CheckPasswordByIdAsync(dto.UserId, dto.CurrentPassword);
            if (!isValidPassword)
                return Unauthorized("Invalid current password.");

            var result = await _authService.ResetPasswordAsync(new ResetPassword(){ UserId = dto.UserId, PasswordDto = dto.PasswordDto });
            if (result)
                return Ok("Password reset successfully.");
           
            return StatusCode(500, "Internal error. Failed to reset password. Please try again later.");
        }

        [HttpPatch("users/{id}/password")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ResetPassword([FromRoute] string id, [FromBody] NewPasswordDto dto, [FromServices] IValidator<NewPasswordDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            var rpDto = new ResetPassword { UserId = id, PasswordDto = dto };

            var result = await _authService.ResetPasswordAsync(rpDto);
            if (result)
                return Ok("Password reset successfully.");
            
            return StatusCode(500, "Internal error. Failed to reset password. Please try again later.");
        }

        [HttpPatch("password/forgot")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] SchoolMailDto schoolMail, [FromServices] IValidator<SchoolMailDto> validator)
        {
            var validationResult = await validator.ValidateAsync(schoolMail);
            if (!validationResult.IsValid)
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            // Control of user is done in the service layer since it has access to the database via _userService
            var token = await _authService.GetResetTokenAsync(schoolMail.SchoolMail);

            string link = $"https://example.com/reset-password?token={token}";

            // To be implemented: Send email with the link to the user
            return Ok(new { message = "Check your email for the reset password link.", link });
        }
    }
}
