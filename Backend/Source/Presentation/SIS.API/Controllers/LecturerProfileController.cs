using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.LecturerProfileDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing Lecturer Profiles within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/profiles/lecturer")]
    [ApiController]
    public class LecturerProfileController(ILecturerProfileRepository lecturerProfileRepository) : ControllerBase
    {
        private readonly ILecturerProfileRepository _lecturerProfileRepository = lecturerProfileRepository;

        /// <summary>
        /// Retrieves all profiles of Lecturers.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of LecturerProfiles.</returns>
        /// <response code="200">Returns the list of LecturerProfiles.</response>
        /// <response code="404">No Lecturer Profiles found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLecturerProfiles(CancellationToken cancellationToken)
        {
            IEnumerable<LecturerProfile> lecturerProfiles = await _lecturerProfileRepository.GetAllLecturerProfiles(cancellationToken);
            if (lecturerProfiles == null || !lecturerProfiles.Any())
            {
                return NotFound("No Lecturer Profile found.");
            }

            return Ok(lecturerProfiles.Select(u => u.ToProfileGetDto()));
        }

        /// <summary>
        /// Retrieves an Lecturer Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Lecturer Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Lecturer Profile with the specified ID.</returns>
        /// <response code="200">Returns the Lecturer Profile.</response>
        /// <response code="404">Lecturer Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLecturerProfileById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "LecturerProfile");

            LecturerProfile? lecturerProfile = await _lecturerProfileRepository.GetLecturerProfileByIdAsync(id, cancellationToken);
            if (lecturerProfile == null)
                return NotFound($"Lecturer Profile not found.");

            return Ok(lecturerProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Creates a new Lecturer Profile.
        /// </summary>
        /// <param name="LecturerProfileCreateDto">The DTO containing the Lecturer Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Lecturer Profile.</returns>
        /// <response code="201">Lecturer Profile created successfully.</response>
        /// <response code="400">Invalid Lecturer Profile data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateLecturerProfile(LecturerProfileCreateDto LecturerProfileCreateDto, [FromServices] IValidator<LecturerProfileCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(LecturerProfileCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            LecturerProfile lecturerProfile = LecturerProfileCreateDto.ToProfile();

            LecturerProfile result = await _lecturerProfileRepository.CreateLecturerProfileAsync(lecturerProfile, cancellationToken);

            return CreatedAtAction(nameof(GetLecturerProfileById), new { id = result.Id }, result.ToProfileGetDto());
        }

        /// <summary>
        /// Updates an existing Lecturer Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Lecturer Profile.</param>
        /// <param name="lecturerProfileUpdateDto">The DTO containing the updated Lecturer Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Lecturer Profile.</returns>
        /// <response code="200">Lecturer Profile updated successfully.</response>
        /// <response code="400">Invalid Lecturer Profile data.</response>
        /// <response code="404">Lecturer Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateLecturerProfile([FromRoute] int id, LecturerProfileUpdateDto lecturerProfileUpdateDto, [FromServices] IValidator<LecturerProfileUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, lecturerProfileUpdateDto.Id, "LecturerProfile");

            ValidationResult validationResult = await validator.ValidateAsync(lecturerProfileUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            LecturerProfile? existingLecturerProfile = await _lecturerProfileRepository.GetLecturerProfileByIdAsync(id, cancellationToken);
            if (existingLecturerProfile == null)
                return NotFound($"Lecturer Profile not found.");

            existingLecturerProfile.ApplyUpdate(lecturerProfileUpdateDto);

            await _lecturerProfileRepository.UpdateLecturerProfileAsync(existingLecturerProfile, cancellationToken);

            return Ok(existingLecturerProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Partially updates an existing Lecturer Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Lecturer Profile.</param>
        /// <param name="lecturerProfilePatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Lecturer Profile.</returns>
        /// <response code="200">Lecturer Profile patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Lecturer Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchLecturerProfile([FromRoute] int id, [FromBody] LecturerProfilePatchDto lecturerProfilePatchDto, [FromServices] IValidator<LecturerProfilePatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, lecturerProfilePatchDto.Id, "LecturerProfile");

            ValidationResult validationResult = await validator.ValidateAsync(lecturerProfilePatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            LecturerProfile? existingLecturerProfile = await _lecturerProfileRepository.GetLecturerProfileByIdAsync(id, cancellationToken);
            if (existingLecturerProfile == null)
                return NotFound($"Lecturer Profile not found.");

            existingLecturerProfile.ApplyPatch(lecturerProfilePatchDto);

            await _lecturerProfileRepository.UpdateLecturerProfileAsync(existingLecturerProfile, cancellationToken);

            return Ok(existingLecturerProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Deletes an Lecturer Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Lecturer Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Lecturer Profile deleted successfully.</response>
        /// <response code="400">Invalid Lecturer Profile ID.</response>
        /// <response code="404">Lecturer Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteLecturerProfile([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "LecturerProfile");

            LecturerProfile? lecturerProfile = await _lecturerProfileRepository.GetLecturerProfileByIdAsync(id, cancellationToken);
            if (lecturerProfile == null)
                return NotFound($"Lecturer Profile not found.");

            await _lecturerProfileRepository.DeleteLecturerProfileAsync(lecturerProfile, cancellationToken);

            return NoContent();
        }
    }
}
