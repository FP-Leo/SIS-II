using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;

namespace SIS.API.Controllers
{
    [Route("api/v{version:apiVersion}/universities")]
    [ApiController]
    public class UniversitiesController(IUniversityRepository universityRepo) : ControllerBase
    {
        private readonly IUniversityRepository _universityRepo = universityRepo;

        // Codes: 200 - OK, 400 - Bad Request, 401 - Unauthorized, 404 - Not Found, 500 - Internal Server Error

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UniversityGetDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllUniversities(CancellationToken cancellationToken)
        {
            var universities = await _universityRepo.GetAllUniversitiesAsync(cancellationToken);

            if (universities == null || !universities.Any())
                return NotFound(ErrorMessages.UniversitiesNotFound);

            return Ok(universities.Select(u => u.ToUniversityGetDto()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UniversityGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUniversityById([FromRoute]int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            var university = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (university == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            return Ok(university.ToUniversityGetDto());
        }

        [HttpPost]
        [ProducesResponseType(typeof(UniversityGetDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize("Admin")]
        public async Task<IActionResult> CreateUniversity([FromBody] UniversityCreateDto university, [FromServices] IValidator<UniversityCreateDto> validator, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(university, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var transformedUniversity = university.ToUniversity();

            var createdUniversity = await _universityRepo.CreateUniversityAsync(transformedUniversity, cancellationToken);
            return CreatedAtAction(nameof(GetUniversityById), new { id = createdUniversity.Id }, transformedUniversity.ToUniversityGetDto());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UniversityGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateUniversity(int id, [FromBody] UniversityUpdateDto university, [FromServices] IValidator<UniversityUpdateDto> validator,CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            var existingUniversity = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (existingUniversity == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            var validationResult = await validator.ValidateAsync(university, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingUniversity.ApplyUpdate(university);

            await _universityRepo.UpdateUniversityAsync(existingUniversity, cancellationToken);

            return Ok(existingUniversity.ToUniversityGetDto());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUniversity([FromRoute] int id, [FromBody] UniversityPatchDto university, [FromServices] IValidator<UniversityPatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            var existingUniversity = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (existingUniversity == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            var validationResult = await validator.ValidateAsync(university, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingUniversity.ApplyPatch(university);

            await _universityRepo.UpdateUniversityAsync(existingUniversity, cancellationToken);

            return Ok(existingUniversity.ToUniversityGetDto());
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteUniversity([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "University");

            var university = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (university == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            await _universityRepo.DeleteUniversityByIdAsync(university, cancellationToken);
            return NoContent();
        }
    }
}
