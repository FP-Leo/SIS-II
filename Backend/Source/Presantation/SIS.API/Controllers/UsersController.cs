using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.API.Common;
using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common.Constants;
using System.Security.Claims;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the user details or an error response.</returns>
        /// <remarks>
        /// Authorization: Requires the user to be authenticated. Only accessible by the user themselves, administrators, or superusers.
        /// HTTP Status Codes:
        /// - 200: User retrieved successfully.
        /// - 400: Bad request.
        /// - 401: Unauthorized.
        /// - 404: User not found.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UserGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role)
                                    .Select(c => c.Value)
                                    .ToList();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized(ErrorMessages.UnAuthorized);

            if (!roles.Contains(RoleConstants.SuperUser) && !roles.Contains(RoleConstants.Administrator) && userId != id)
                return Unauthorized(ErrorMessages.UnAuthorized);

            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            return Ok(user.ToUserGetDto());
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userCreateDto">The data for the new user.</param>
        /// <param name="validator">The validator for the user creation data.</param>
        /// <returns>An <see cref="IActionResult"/> containing the created user details or an error response.</returns>
        /// <remarks>
        /// Authorization: Requires the user to be an administrator or superuser.
        /// HTTP Status Codes:
        /// - 201: User created successfully.
        /// - 400: Validation failed.
        /// - 401: Unauthorized.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.SuperUser}, {RoleConstants.Administrator}")]
        [ProducesResponseType(typeof(UserSuccessfulRegistrationDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser(
            [FromBody] UserCreateDto userCreateDto, 
            [FromServices] IValidator<UserCreateDto> validator
            )
        {
            var validationResult = await validator.ValidateAsync(userCreateDto);

            if (!validationResult.IsValid) 
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            var token = await _userService.RegisterUserAsync(userCreateDto);

            return CreatedAtAction(nameof(GetUser), new { id = userCreateDto.UserName }, new UserSuccessfulRegistrationDto
            {
                UserName = userCreateDto.UserName,
                Token = token
            });
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userPatchDto">The data to update the user with.</param>
        /// <param name="validator">The validator for the user update data.</param>
        /// <returns>An <see cref="IActionResult"/> containing the updated user details or an error response.</returns>
        /// <remarks>
        /// Authorization: Requires the user to be an administrator or superuser.
        /// HTTP Status Codes:
        /// - 200: User updated successfully.
        /// - 400: Validation failed.
        /// - 401: Unauthorized.
        /// - 404: User not found.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpPatch("{id}")]
        [Authorize(Roles = $"{RoleConstants.SuperUser}, {RoleConstants.Administrator}")]
        [ProducesResponseType(typeof(UserGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] string id, 
            [FromBody] UserPatchDto userPatchDto, 
            [FromServices] IValidator<UserPatchDto> validator
            )
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            var validationResult = await validator.ValidateAsync(userPatchDto);

            if (!validationResult.IsValid)
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            user.ApplyPatch(userPatchDto);

            await _userService.UpdateUserAsync(user);

            return Ok(user.ToUserGetDto());
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <remarks>
        /// Authorization: Requires the user to be a superuser.
        /// HTTP Status Codes:
        /// - 204: User deleted successfully.
        /// - 400: Bad request.
        /// - 401: Unauthorized.
        /// - 404: User not found.
        /// - 500: Internal server error.
        /// </remarks>
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleConstants.SuperUser)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            await _userService.DeleteUserAsync(user);

            return NoContent();
        }
    }
}
