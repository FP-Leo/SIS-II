using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Interfaces.Services;
using SIS.Application.Interfaces.Validators;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common.Constants;
using SIS.Domain.Entities;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.Database;
using SIS.Domain.Exceptions.University;
using SIS.Infrastructure.Validators;
using System.Threading;

namespace SIS.API.Controllers
{
    [Route("api/v{version:apiVersion}/universities")]
    [ApiController]
    public class UniversitiesController(IUniversityRepository universityRepo, IUniversityValidator universityValidator, IUserService userService) : ControllerBase
    {
        private readonly IUniversityRepository _universityRepo = universityRepo;
        private readonly IUniversityValidator _universityValidator = universityValidator;
        private readonly IUserService _userService = userService;

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
        public async Task<IActionResult> CreateUniversity([FromBody] UniversityCreateDto university, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(university.RectorId);
            if (user == null)
                return NotFound(ErrorMessages.RectorNotFound);

            var transformedUniversity = university.ToUniversity(user);

            await _universityValidator.ValidateUniversityAsync(transformedUniversity, cancellationToken);

            var createdUniversity = await _universityRepo.CreateUniversityAsync(transformedUniversity, cancellationToken);
            return CreatedAtAction(nameof(GetUniversityById), new { id = createdUniversity.Id }, new { id = createdUniversity.Id });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UniversityGetDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUniversity(int id, [FromBody] UniversityUpdateDto university, CancellationToken cancellationToken)
        {
            var existingUniversity = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (existingUniversity == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            var user = await _userService.GetUserByIdAsync(university.RectorId);
            if (user == null)
                return NotFound(ErrorMessages.RectorNotFound);

            existingUniversity.Name = university.Name;
            existingUniversity.Abbreviation = university.Abbreviation;
            existingUniversity.Address = university.Address;
            existingUniversity.Domain = university.Domain;
            existingUniversity.RectorId = user.Id;
            existingUniversity.Rector = user;

            await _universityValidator.ValidateUniversityAsync(existingUniversity, cancellationToken);

            await _universityRepo.UpdateUniversityAsync(existingUniversity, cancellationToken);

            return Ok(existingUniversity.ToUniversityGetDto());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUniversity([FromRoute] int id, [FromBody] UniversityPatchDto university, CancellationToken cancellationToken)
        {
            var existingUniversity = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (existingUniversity == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            await existingUniversity.ApplyPatchAsync(university, _userService);

            await _universityRepo.UpdateUniversityAsync(existingUniversity, cancellationToken);

            return Ok(existingUniversity.ToUniversityGetDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity([FromRoute] int id, CancellationToken cancellationToken)
        {
            var university = await _universityRepo.GetUniversityByIdAsync(id, cancellationToken);
            if (university == null)
                return NotFound(ErrorMessages.UniversityNotFound);

            await _universityRepo.DeleteUniversityByIdAsync(university, cancellationToken);
            return Ok();
        }
    }
}
