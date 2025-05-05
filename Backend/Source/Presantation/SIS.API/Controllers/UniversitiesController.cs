using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing universities.
    /// </summary>
    [Route("api/v{version:apiVersion}/universities")]
    [ApiController]
    public class UniversitiesController(IUniversityRepository universityRepo) : ControllerBase
    {
        private readonly IUniversityRepository _universityRepo = universityRepo;

        /// <summary>
        /// Retrieves all universities.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A list of universities.</returns>
        /// <response code="200">Returns the list of universities.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="404">If no universities are found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UniversityGetDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllUniversities(CancellationToken cancellationToken)
        {
            IEnumerable<University> universities = await _universityRepo.GetAllUniversitiesAsync(cancellationToken);

            if (universities == null || !universities.Any())
                return NotFound("No universities found.");

            return Ok(universities.Select(u => u.ToUniversityGetDto()));
        }

        /// <summary>
        /// Retrieves a university by its ID.
        /// </summary>
        /// <param name="id">The ID of the university.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>The university with the specified ID.</returns>
        /// <response code="200">Returns the university.</response>
        /// <response code="400">If the ID is invalid.</response>
        /// <response code="404">If the university is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UniversityGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUniversityById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            University? university = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (university == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            return Ok(university.ToUniversityGetDto());
        }

        /// <summary>
        /// Creates a new university.
        /// </summary>
        /// <param name="university">The university to create.</param>
        /// <param name="validator">The validator for the university DTO.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>The created university.</returns>
        /// <response code="201">Returns the created university.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpPost]
        [ProducesResponseType(typeof(UniversityGetDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateUniversity([FromBody] UniversityCreateDto university, [FromServices] IValidator<UniversityCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(university, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            University transformedUniversity = university.ToUniversity();

            University createdUniversity = await _universityRepo.CreateUniversityAsync(transformedUniversity, cancellationToken);
            return CreatedAtAction(nameof(GetUniversityById), new { id = createdUniversity.Id }, transformedUniversity.ToUniversityGetDto());
        }

        /// <summary>
        /// Updates an existing university.
        /// </summary>
        /// <param name="id">The ID of the university to update.</param>
        /// <param name="university">The updated university data.</param>
        /// <param name="validator">The validator for the university DTO.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>The updated university.</returns>
        /// <response code="200">Returns the updated university.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="404">If the university is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(UniversityGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateUniversity([FromRoute] int id, [FromBody] UniversityUpdateDto university, [FromServices] IValidator<UniversityUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            University? existingUniversity = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (existingUniversity == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            ValidationResult validationResult = await validator.ValidateAsync(university, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingUniversity.ApplyUpdate(university);

            await _universityRepo.UpdateUniversityAsync(existingUniversity, cancellationToken);

            return Ok(existingUniversity.ToUniversityGetDto());
        }

        /// <summary>
        /// Partially updates an existing university.
        /// </summary>
        /// <param name="id">The ID of the university to update.</param>
        /// <param name="university">The partial update data.</param>
        /// <param name="validator">The validator for the university DTO.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>The updated university.</returns>
        /// <response code="200">Returns the updated university.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="404">If the university is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(typeof(UniversityGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchUniversity([FromRoute] int id, [FromBody] UniversityPatchDto university, [FromServices] IValidator<UniversityPatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            University? existingUniversity = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (existingUniversity == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            ValidationResult validationResult = await validator.ValidateAsync(university, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingUniversity.ApplyPatch(university);

            await _universityRepo.UpdateUniversityAsync(existingUniversity, cancellationToken);

            return Ok(existingUniversity.ToUniversityGetDto());
        }

        /// <summary>
        /// Deletes a university by its ID.
        /// </summary>
        /// <param name="id">The ID of the university to delete.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">If the university is successfully deleted.</response>
        /// <response code="400">If the ID is invalid.</response>
        /// <response code="404">If the university is not found.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize(RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteUniversity([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            University? university = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (university == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            await _universityRepo.DeleteUniversityByIdAsync(university, cancellationToken);
            return NoContent();
        }
    }
}
