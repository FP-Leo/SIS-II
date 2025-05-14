using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.FacultyDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing faculties within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/faculties")]
    [ApiController]
    public class FacultyController(IFacultyRepository facultyRepository) : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository = facultyRepository;

        /// <summary>
        /// Retrieves all faculties.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of faculties.</returns>
        /// <response code="200">Returns the list of faculties.</response>
        /// <response code="404">No faculties found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFaculties(CancellationToken cancellationToken)
        {
            IEnumerable<Faculty> faculties = await _facultyRepository.GetAllFacultiesAsync(cancellationToken);
            if (faculties == null || !faculties.Any())
            {
                return NotFound("No faculties found.");
            }

            return Ok(faculties.Select(u => u.ToFacultyGetDto()));
        }

        /// <summary>
        /// Retrieves a faculty by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The faculty with the specified ID.</returns>
        /// <response code="200">Returns the faculty.</response>
        /// <response code="404">Faculty not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFacultyById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Faculty");

            Faculty? faculty = await _facultyRepository.GetFacultyByIdAsync(id, cancellationToken);
            if (faculty == null)
                return NotFound($"Faculty not found.");

            return Ok(faculty.ToFacultyGetDto());
        }

        /// <summary>
        /// Creates a new faculty.
        /// </summary>
        /// <param name="facultyCreateDto">The DTO containing the faculty data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created faculty.</returns>
        /// <response code="201">Faculty created successfully.</response>
        /// <response code="400">Invalid faculty data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateFaculty(FacultyCreateDto facultyCreateDto, [FromServices] IValidator<FacultyCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(facultyCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Faculty faculty = facultyCreateDto.ToFaculty();

            Faculty result = await _facultyRepository.CreateFacultyAsync(faculty, cancellationToken);

            return CreatedAtAction(nameof(GetFacultyById), new { id = result.Id }, result.ToFacultyGetDto());
        }

        /// <summary>
        /// Updates an existing faculty.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty.</param>
        /// <param name="facultyUpdateDto">The DTO containing the updated faculty data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated faculty.</returns>
        /// <response code="200">Faculty updated successfully.</response>
        /// <response code="400">Invalid faculty data.</response>
        /// <response code="404">Faculty not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateFaculty([FromRoute] int id, FacultyUpdateDto facultyUpdateDto, [FromServices] IValidator<FacultyUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, facultyUpdateDto.Id, "Faculty");

            ValidationResult validationResult = await validator.ValidateAsync(facultyUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Faculty? existingFaculty = await _facultyRepository.GetFacultyByIdAsync(id, cancellationToken);
            if (existingFaculty == null)
                return NotFound($"Faculty not found.");

            existingFaculty.ApplyUpdate(facultyUpdateDto);

            await _facultyRepository.UpdateFacultyAsync(existingFaculty, cancellationToken);

            return Ok(existingFaculty.ToFacultyGetDto());
        }

        /// <summary>
        /// Partially updates an existing faculty.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty.</param>
        /// <param name="facultyPatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated faculty.</returns>
        /// <response code="200">Faculty patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Faculty not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchFaculty([FromRoute] int id, [FromBody] FacultyPatchDto facultyPatchDto, [FromServices] IValidator<FacultyPatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsSame(id, facultyPatchDto.Id, "Faculty");

            ValidationResult validationResult = await validator.ValidateAsync(facultyPatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Faculty? existingFaculty = await _facultyRepository.GetFacultyByIdAsync(id, cancellationToken);
            if (existingFaculty == null)
                return NotFound($"Faculty not found.");

            existingFaculty.ApplyPatch(facultyPatchDto);

            await _facultyRepository.UpdateFacultyAsync(existingFaculty, cancellationToken);

            return Ok(existingFaculty.ToFacultyGetDto());
        }

        /// <summary>
        /// Deletes a faculty by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the faculty.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Faculty deleted successfully.</response>
        /// <response code="400">Invalid faculty ID.</response>
        /// <response code="404">Faculty not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteFaculty([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Faculty");

            Faculty? faculty = await _facultyRepository.GetFacultyByIdAsync(id, cancellationToken);
            if (faculty == null)
                return NotFound($"Faculty not found.");

            await _facultyRepository.DeleteFacultyByIdAsync(faculty, cancellationToken);

            return NoContent();
        }
    }
}
