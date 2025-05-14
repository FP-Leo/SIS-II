using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.AdvisorProfileDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing Advisor Profiles within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/profiles/advisor")]
    [ApiController]
    public class AdvisorProfileController(IAdvisorProfileRepository AdvisorProfileRepository) : ControllerBase
    {
        private readonly IAdvisorProfileRepository _AdvisorProfileRepository = AdvisorProfileRepository;

        /// <summary>
        /// Retrieves all profiles of Advisors.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of AdvisorProfiles.</returns>
        /// <response code="200">Returns the list of AdvisorProfiles.</response>
        /// <response code="404">No Advisor Profiles found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAdvisorProfiles(CancellationToken cancellationToken)
        {
            IEnumerable<AdvisorProfile> AdvisorProfiles = await _AdvisorProfileRepository.GetAllAdvisorProfiles(cancellationToken);
            if (AdvisorProfiles == null || !AdvisorProfiles.Any())
            {
                return NotFound("No Advisor Profiles found.");
            }

            return Ok(AdvisorProfiles.Select(u => u.ToProfileGetDto()));
        }

        /// <summary>
        /// Retrieves an Advisor Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Advisor Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Advisor Profile with the specified ID.</returns>
        /// <response code="200">Returns the Advisor Profile.</response>
        /// <response code="404">Advisor Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAdvisorProfileById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "AdvisorProfile");

            AdvisorProfile? AdvisorProfile = await _AdvisorProfileRepository.GetAdvisorProfileByIdAsync(id, cancellationToken);
            if (AdvisorProfile == null)
                return NotFound($"Advisor Profile not found.");

            return Ok(AdvisorProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Creates a new Advisor Profile.
        /// </summary>
        /// <param name="advisorProfileCreateDto">The DTO containing the Advisor Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Advisor Profile.</returns>
        /// <response code="201">Advisor Profile created successfully.</response>
        /// <response code="400">Invalid Advisor Profile data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateAdvisorProfile(AdvisorProfileCreateDto advisorProfileCreateDto, [FromServices] IValidator<AdvisorProfileCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(advisorProfileCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AdvisorProfile AdvisorProfile = advisorProfileCreateDto.ToProfile();

            AdvisorProfile result = await _AdvisorProfileRepository.CreateAdvisorProfileAsync(AdvisorProfile, cancellationToken);

            return CreatedAtAction(nameof(GetAdvisorProfileById), new { id = result.Id }, result.ToProfileGetDto());
        }

        /// <summary>
        /// Updates an existing Advisor Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Advisor Profile.</param>
        /// <param name="advisorProfileUpdateDto">The DTO containing the updated Advisor Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Advisor Profile.</returns>
        /// <response code="200">Advisor Profile updated successfully.</response>
        /// <response code="400">Invalid Advisor Profile data.</response>
        /// <response code="404">Advisor Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateAdvisorProfile([FromRoute] int id, AdvisorProfileUpdateDto advisorProfileUpdateDto, [FromServices] IValidator<AdvisorProfileUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, advisorProfileUpdateDto.Id, "AdvisorProfile");

            ValidationResult validationResult = await validator.ValidateAsync(advisorProfileUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AdvisorProfile? existingAdvisorProfile = await _AdvisorProfileRepository.GetAdvisorProfileByIdAsync(id, cancellationToken);
            if (existingAdvisorProfile == null)
                return NotFound($"AdvisorProfile with ID {id} not found.");

            existingAdvisorProfile.ApplyUpdate(advisorProfileUpdateDto);

            await _AdvisorProfileRepository.UpdateAdvisorProfileAsync(existingAdvisorProfile, cancellationToken);

            return Ok(existingAdvisorProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Partially updates an existing Advisor Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Advisor Profile.</param>
        /// <param name="advisorProfilePatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Advisor Profile.</returns>
        /// <response code="200">Advisor Profile patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Advisor Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchAdvisorProfile([FromRoute] int id, [FromBody] AdvisorProfilePatchDto advisorProfilePatchDto, [FromServices] IValidator<AdvisorProfilePatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, advisorProfilePatchDto.Id, "AdvisorProfile");

            ValidationResult validationResult = await validator.ValidateAsync(advisorProfilePatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            AdvisorProfile? existingAdvisorProfile = await _AdvisorProfileRepository.GetAdvisorProfileByIdAsync(id, cancellationToken);
            if (existingAdvisorProfile == null)
                return NotFound($"Advisor Profile not found.");

            existingAdvisorProfile.ApplyPatch(advisorProfilePatchDto);

            await _AdvisorProfileRepository.UpdateAdvisorProfileAsync(existingAdvisorProfile, cancellationToken);

            return Ok(existingAdvisorProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Deletes an Advisor Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Advisor Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Advisor Profile deleted successfully.</response>
        /// <response code="400">Invalid Advisor Profile ID.</response>
        /// <response code="404">Advisor Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteAdvisorProfile([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "AdvisorProfile");

            AdvisorProfile? AdvisorProfile = await _AdvisorProfileRepository.GetAdvisorProfileByIdAsync(id, cancellationToken);
            if (AdvisorProfile == null)
                return NotFound($"Advisor Profile not found.");

            await _AdvisorProfileRepository.DeleteAdvisorProfileAsync(AdvisorProfile, cancellationToken);

            return NoContent();
        }
    }
}
