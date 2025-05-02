using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.API.Common;
using SIS.Application.DTOs.UserDTOs;
using SIS.Application.Interfaces.Services;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common.Constants;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        // Codes: 200 - OK, 400 - Bad Request, 401 - Unauthorized, 404 - Not Found, 500 - Internal Server Error

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(UserGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            return Ok(user.ToUserGetDto());
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
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

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
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
            var validationResult = await validator.ValidateAsync(userPatchDto);

            if (!validationResult.IsValid)
                return BadRequest(ControllerUtil.CreateValidationProblemDetails(validationResult, HttpContext.Request.Path));

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(ErrorMessages.UserNotFound);

            user.ApplyPatch(userPatchDto);

            await _userService.UpdateUserAsync(user);

            return Ok(user.ToUserGetDto());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
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
