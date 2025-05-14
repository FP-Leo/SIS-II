using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.AdministratorProfileDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing Administrator Profiles within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/profiles/administrator")]
    [ApiController]
    public class AdministratorProfileController(IAdministratorProfileRepository administratorProfileRepository) : ControllerBase
    {
        private readonly IAdministratorProfileRepository _administratorProfileRepository = administratorProfileRepository;

        /// <summary>
        /// Retrieves all profiles of Administrators.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of administratorProfiles.</returns>
        /// <response code="200">Returns the list of administratorProfiles.</response>
        /// <response code="404">No Administrator Profiles found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAdministratorProfiles(CancellationToken cancellationToken)
        {
            IEnumerable<AdministratorProfile> administratorProfiles = await _administratorProfileRepository.GetAllAdministratorProfiles(cancellationToken);
            if (administratorProfiles == null || !administratorProfiles.Any())
            {
                return NotFound("No administratorProfiles found.");
            }

            return Ok(administratorProfiles.Select(u => u.ToProfileGetDto()));
        }

        /// <summary>
        /// Retrieves an Administrator Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Administrator Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Administrator Profile with the specified ID.</returns>
        /// <response code="200">Returns the Administrator Profile.</response>
        /// <response code="404">Administrator Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdministratorProfileById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "AdministratorProfile");

            AdministratorProfile? administratorProfile = await _administratorProfileRepository.GetAdministratorProfileByIdAsync(id, cancellationToken);
            if (administratorProfile == null)
                return NotFound($"AdministratorProfile with ID {id} not found.");

            return Ok(administratorProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Creates a new Administrator Profile.
        /// </summary>
        /// <param name="administratorProfileCreateDto">The DTO containing the Administrator Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Administrator Profile.</returns>
        /// <response code="201">Administrator Profile created successfully.</response>
        /// <response code="400">Invalid Administrator Profile data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateAdministratorProfile(AdministratorProfileCreateDto administratorProfileCreateDto, [FromServices] IValidator<AdministratorProfileCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(administratorProfileCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AdministratorProfile administratorProfile = administratorProfileCreateDto.ToProfile();

            AdministratorProfile result = await _administratorProfileRepository.CreateAdministratorProfileAsync(administratorProfile, cancellationToken);

            return CreatedAtAction(nameof(GetAdministratorProfileById), new { id = result.Id }, result.ToProfileGetDto());
        }

        /// <summary>
        /// Updates an existing Administrator Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Administrator Profile.</param>
        /// <param name="administratorProfileUpdateDto">The DTO containing the updated Administrator Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Administrator Profile.</returns>
        /// <response code="200">Administrator Profile updated successfully.</response>
        /// <response code="400">Invalid Administrator Profile data.</response>
        /// <response code="404">Administrator Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateAdministratorProfile([FromRoute] int id, AdministratorProfileUpdateDto administratorProfileUpdateDto, [FromServices] IValidator<AdministratorProfileUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, administratorProfileUpdateDto.Id, "AdministratorProfile");

            ValidationResult validationResult = await validator.ValidateAsync(administratorProfileUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AdministratorProfile? existingAdministratorProfile = await _administratorProfileRepository.GetAdministratorProfileByIdAsync(id, cancellationToken);
            if (existingAdministratorProfile == null)
                return NotFound($"AdministratorProfile with ID {id} not found.");

            existingAdministratorProfile.ApplyUpdate(administratorProfileUpdateDto);

            await _administratorProfileRepository.UpdateAdministratorProfileAsync(existingAdministratorProfile, cancellationToken);

            return Ok(existingAdministratorProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Partially updates an existing Administrator Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Administrator Profile.</param>
        /// <param name="administratorProfilePatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Administrator Profile.</returns>
        /// <response code="200">Administrator Profile patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Administrator Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchAdministratorProfile([FromRoute] int id, [FromBody] AdministratorProfilePatchDto administratorProfilePatchDto, [FromServices] IValidator<AdministratorProfilePatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, administratorProfilePatchDto.Id, "AdministratorProfile");

            ValidationResult validationResult = await validator.ValidateAsync(administratorProfilePatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AdministratorProfile? existingAdministratorProfile = await _administratorProfileRepository.GetAdministratorProfileByIdAsync(id, cancellationToken);
            if (existingAdministratorProfile == null)
                return NotFound($"AdministratorProfile with ID {id} not found.");

            existingAdministratorProfile.ApplyPatch(administratorProfilePatchDto);

            await _administratorProfileRepository.UpdateAdministratorProfileAsync(existingAdministratorProfile, cancellationToken);

            return Ok(existingAdministratorProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Deletes an Administrator Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Administrator Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Administrator Profile deleted successfully.</response>
        /// <response code="400">Invalid Administrator Profile ID.</response>
        /// <response code="404">Administrator Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteAdministratorProfile([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "AdministratorProfile");

            AdministratorProfile? administratorProfile = await _administratorProfileRepository.GetAdministratorProfileByIdAsync(id, cancellationToken);
            if (administratorProfile == null)
                return NotFound($"AdministratorProfile with ID {id} not found.");

            await _administratorProfileRepository.DeleteAdministratorProfileAsync(administratorProfile, cancellationToken);

            return NoContent();
        }
    }
}
