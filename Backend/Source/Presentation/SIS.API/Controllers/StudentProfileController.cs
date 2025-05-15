using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.StudentProfileDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing student Profiles within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/profiles/student")]
    [ApiController]
    public class StudentProfileController(IStudentProfileRepository studentProfileRepository) : ControllerBase
    {
        private readonly IStudentProfileRepository _studentProfileRepository = studentProfileRepository;

        /// <summary>
        /// Retrieves all profiles of Students.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of Student Profiles.</returns>
        /// <response code="200">Returns the list of Student Profiles.</response>
        /// <response code="404">No Student Profiles found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStudentProfiles(CancellationToken cancellationToken)
        {
            IEnumerable<StudentProfile> studentProfiles = await _studentProfileRepository.GetAllStudentProfiles(cancellationToken);
            if (studentProfiles == null || !studentProfiles.Any())
            {
                return NotFound("No Student Profiles found.");
            }

            return Ok(studentProfiles.Select(u => u.ToProfileGetDto()));
        }

        /// <summary>
        /// Retrieves an Student Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Student Profile with the specified ID.</returns>
        /// <response code="200">Returns the Student Profile.</response>
        /// <response code="404">Student Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentProfileById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "StudentProfile");

            StudentProfile? studentProfile = await _studentProfileRepository.GetStudentProfileByIdAsync(id, cancellationToken);
            if (studentProfile == null)
                return NotFound($"Student Profile not found.");

            return Ok(studentProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Creates a new Student Profile.
        /// </summary>
        /// <param name="studentProfileCreateDto">The DTO containing the Student Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created student Profile.</returns>
        /// <response code="201">Student Profile created successfully.</response>
        /// <response code="400">Invalid Student Profile data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateStudentProfile(StudentProfileCreateDto studentProfileCreateDto, [FromServices] IValidator<StudentProfileCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(studentProfileCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            StudentProfile studentProfile = studentProfileCreateDto.ToProfile();

            StudentProfile result = await _studentProfileRepository.CreateStudentProfileAsync(studentProfile, cancellationToken);

            return CreatedAtAction(nameof(GetStudentProfileById), new { id = result.Id }, result.ToProfileGetDto());
        }

        /// <summary>
        /// Updates an existing Student Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Profile.</param>
        /// <param name="studentProfileUpdateDto">The DTO containing the updated Student Profile data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Student Profile.</returns>
        /// <response code="200">Student Profile updated successfully.</response>
        /// <response code="400">Invalid student Profile data.</response>
        /// <response code="404">Student Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateStudentProfile([FromRoute] int id, StudentProfileUpdateDto studentProfileUpdateDto, [FromServices] IValidator<StudentProfileUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, studentProfileUpdateDto.Id, "StudentProfile");

            ValidationResult validationResult = await validator.ValidateAsync(studentProfileUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            StudentProfile? existingstudentProfile = await _studentProfileRepository.GetStudentProfileByIdAsync(id, cancellationToken);
            if (existingstudentProfile == null)
                return NotFound($"Student Profile not found.");

            existingstudentProfile.ApplyUpdate(studentProfileUpdateDto);

            await _studentProfileRepository.UpdateStudentProfileAsync(existingstudentProfile, cancellationToken);

            return Ok(existingstudentProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Partially updates an existing Student Profile.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Profile.</param>
        /// <param name="studentProfilePatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Student Profile.</returns>
        /// <response code="200">Student Profile patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Student Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchstudentProfile([FromRoute] int id, [FromBody] StudentProfilePatchDto studentProfilePatchDto, [FromServices] IValidator<StudentProfilePatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, studentProfilePatchDto.Id, "StudentProfile");

            ValidationResult validationResult = await validator.ValidateAsync(studentProfilePatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            StudentProfile? existingstudentProfile = await _studentProfileRepository.GetStudentProfileByIdAsync(id, cancellationToken);
            if (existingstudentProfile == null)
                return NotFound($"Student Profile not found.");

            existingstudentProfile.ApplyPatch(studentProfilePatchDto);

            await _studentProfileRepository.UpdateStudentProfileAsync(existingstudentProfile, cancellationToken);

            return Ok(existingstudentProfile.ToProfileGetDto());
        }

        /// <summary>
        /// Deletes an Student Profile by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Student Profile.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Student Profile deleted successfully.</response>
        /// <response code="400">Invalid Student Profile ID.</response>
        /// <response code="404">Student Profile not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteStudentProfile([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "StudentProfile");

            StudentProfile? studentProfile = await _studentProfileRepository.GetStudentProfileByIdAsync(id, cancellationToken);
            if (studentProfile == null)
                return NotFound($"Student Profile not found.");

            await _studentProfileRepository.DeleteStudentProfileAsync(studentProfile, cancellationToken);

            return NoContent();
        }
    }
}
