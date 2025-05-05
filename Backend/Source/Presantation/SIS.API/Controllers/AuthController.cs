using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.API.Common;
using SIS.Application.DTOs.AuthDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Common.Constants;
using System.Security.Claims;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Controller for managing authentication and authorization operations.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// Authenticates a user and generates a token.
        /// </summary>
        /// <param name="loginDto">The login credentials.</param>
        /// <returns>An <see cref="IActionResult"/> containing the authentication result or an error response.</returns>
        /// <remarks>
        /// Authorization: No authentication required.
        /// HTTP Status Codes:
        /// - 200: Login successful.
        /// - 401: Invalid credentials.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpPost("login")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            SuccessfulLoginDto? successfulLogInDto = await _authService.AuthenticateAsync(loginDto);
            if (successfulLogInDto == null)
                return Unauthorized("Invalid credentials.");

            return Ok(successfulLogInDto);
        }

        /// <summary>
        /// Logs out the current user.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> indicating the logout result.</returns>
        /// <remarks>
        /// Authorization: Requires the user to be authenticated.
        /// HTTP Status Codes:
        /// - 200: Logout successful.
        /// - 401: Unauthorized.
        /// </remarks>
        [HttpPost("logout")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out successfully. Please remove the token on the client side." });
        }

        /// <summary>
        /// Allows a user to reset their own password.
        /// </summary>
        /// <param name="dto">The self-reset password data.</param>
        /// <param name="validator">The validator for the self-reset password data.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <remarks>
        /// Authorization: Requires the user to be authenticated.
        /// HTTP Status Codes:
        /// - 200: Password reset successfully.
        /// - 400: Validation failed.
        /// - 401: Unauthorized.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpPatch("password")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> SelfResetPassword([FromBody] SelfResetPasswordDto dto, [FromServices] IValidator<SelfResetPasswordDto> validator)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("User not found.");

            if (userId != dto.UserId)
                return Unauthorized("User ID mismatch.");

            ValidationResult validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            bool isValidPassword = await _authService.CheckPasswordByIdAsync(dto.UserId, dto.CurrentPassword);
            if (!isValidPassword)
                return Unauthorized("Invalid current password.");

            bool result = await _authService.ResetPasswordAsync(new ResetPassword { UserId = dto.UserId, PasswordDto = dto.PasswordDto });
            if (result)
                return Ok("Password reset successfully.");

            return StatusCode(500, "Internal error. Failed to reset password. Please try again later.");
        }

        /// <summary>
        /// Resets a user's password by an administrator or superuser.
        /// </summary>
        /// <param name="id">The ID of the user whose password is being reset.</param>
        /// <param name="dto">The new password data.</param>
        /// <param name="validator">The validator for the new password data.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <remarks>
        /// Authorization: Requires the user to be a superuser or administrator.
        /// HTTP Status Codes:
        /// - 200: Password reset successfully.
        /// - 400: Validation failed.
        /// - 401: Unauthorized.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpPatch("users/{id}/password")]
        [Authorize($"{RoleConstants.SuperUser}, {RoleConstants.Administrator}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Initiates a password reset process for a user who has forgotten their password.
        /// </summary>
        /// <param name="schoolMail">The school email of the user.</param>
        /// <param name="validator">The validator for the school email data.</param>
        /// <returns>An <see cref="IActionResult"/> containing the reset password link or an error response.</returns>
        /// <remarks>
        /// Authorization: No authentication required.
        /// HTTP Status Codes:
        /// - 200: Reset password link generated successfully.
        /// - 400: Validation failed.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpPatch("password/forgot")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] SchoolMailDto schoolMail, [FromServices] IValidator<SchoolMailDto> validator)
        {
            ValidationResult validationResult = await validator.ValidateAsync(schoolMail);
            if (!validationResult.IsValid)
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            // Control of user is done in the service layer since it has access to the database via _userService
            string token = await _authService.GetResetTokenAsync(schoolMail.SchoolMail);

            string link = $"https://example.com/reset-password?token={token}";

            // To be implemented: Send email with the link to the user
            return Ok(new { message = "Check your email for the reset password link.", link });
        }
    }
}
