using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS.Application.DTOs.DepartmentDTOs;
using SIS.Application.Interfaces.Repositories;
using SIS.Application.Mappers;
using SIS.Application.Patchers;
using SIS.Common;
using SIS.Common.Constants;
using SIS.Domain.Entities;

namespace SIS.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing Departments within the system.
    /// </summary>
    [Route("api/v{version:apiVersion}/Departments")]
    [ApiController]
    public class DepartmentController(IDepartmentRepository DepartmentRepository) : ControllerBase
    {
        private readonly IDepartmentRepository _DepartmentRepository = DepartmentRepository;

        /// <summary>
        /// Retrieves all Departments.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A list of Departments.</returns>
        /// <response code="200">Returns the list of Departments.</response>
        /// <response code="404">No Departments found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllDepartments(CancellationToken cancellationToken)
        {
            IEnumerable<Department> Departments = await _DepartmentRepository.GetAllDepartmentsAsync(cancellationToken);
            if (Departments == null || !Departments.Any())
            {
                return NotFound("No Departments found.");
            }

            return Ok(Departments.Select(u => u.ToDepartmentGetDto()));
        }

        /// <summary>
        /// Retrieves a Department by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The Department with the specified ID.</returns>
        /// <response code="200">Returns the Department.</response>
        /// <response code="404">Department not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Department");

            Department? Department = await _DepartmentRepository.GetDepartmentByIdAsync(id, cancellationToken);
            if (Department == null)
                return NotFound($"Department with ID {id} not found.");

            return Ok(Department.ToDepartmentGetDto());
        }

        /// <summary>
        /// Creates a new Department.
        /// </summary>
        /// <param name="DepartmentCreateDto">The DTO containing the Department data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The created Department.</returns>
        /// <response code="201">Department created successfully.</response>
        /// <response code="400">Invalid Department data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> CreateDepartment(DepartmentCreateDto DepartmentCreateDto, [FromServices] IValidator<DepartmentCreateDto> validator, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await validator.ValidateAsync(DepartmentCreateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Department Department = DepartmentCreateDto.ToDepartment();

            Department result = await _DepartmentRepository.CreateDepartmentAsync(Department, cancellationToken);

            return CreatedAtAction(nameof(GetDepartmentById), new { id = result.Id }, result.ToDepartmentGetDto());
        }

        /// <summary>
        /// Updates an existing Department.
        /// </summary>
        /// <param name="id">The unique identifier of the Department.</param>
        /// <param name="DepartmentUpdateDto">The DTO containing the updated Department data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Department.</returns>
        /// <response code="200">Department updated successfully.</response>
        /// <response code="400">Invalid Department data.</response>
        /// <response code="404">Department not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> UpdateDepartment([FromRoute] int id, DepartmentUpdateDto DepartmentUpdateDto, [FromServices] IValidator<DepartmentUpdateDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Department");

            ValidationResult validationResult = await validator.ValidateAsync(DepartmentUpdateDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            Department? existingDepartment = await _DepartmentRepository.GetDepartmentByIdAsync(id, cancellationToken);
            if (existingDepartment == null)
                return NotFound($"Department with ID {id} not found.");

            existingDepartment.ApplyUpdate(DepartmentUpdateDto);

            await _DepartmentRepository.UpdateDepartmentAsync(existingDepartment, cancellationToken);

            return Ok(existingDepartment.ToDepartmentGetDto());
        }

        /// <summary>
        /// Partially updates an existing Department.
        /// </summary>
        /// <param name="id">The unique identifier of the Department.</param>
        /// <param name="DepartmentPatchDto">The DTO containing the patch data.</param>
        /// <param name="validator">The validator for the DTO.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>The updated Department.</returns>
        /// <response code="200">Department patched successfully.</response>
        /// <response code="400">Invalid patch data.</response>
        /// <response code="404">Department not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> PatchDepartment([FromRoute] int id, [FromBody] DepartmentPatchDto DepartmentPatchDto, [FromServices] IValidator<DepartmentPatchDto> validator, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Department");

            Department? existingDepartment = await _DepartmentRepository.GetDepartmentByIdAsync(id, cancellationToken);
            if (existingDepartment == null)
                return NotFound($"Department with ID {id} not found.");

            ValidationResult validationResult = await validator.ValidateAsync(DepartmentPatchDto, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            existingDepartment.ApplyPatch(DepartmentPatchDto);

            await _DepartmentRepository.UpdateDepartmentAsync(existingDepartment, cancellationToken);

            return Ok(existingDepartment.ToDepartmentGetDto());
        }

        /// <summary>
        /// Deletes a Department by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the Department.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>No content.</returns>
        /// <response code="204">Department deleted successfully.</response>
        /// <response code="400">Invalid Department ID.</response>
        /// <response code="404">Department not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = RoleConstants.SuperUser)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id, CancellationToken cancellationToken)
        {
            CommonUtils.EnsureIdIsValid(id, "Department");

            Department? Department = await _DepartmentRepository.GetDepartmentByIdAsync(id, cancellationToken);
            if (Department == null)
                return NotFound($"Department with ID {id} not found.");

            await _DepartmentRepository.DeleteDepartmentByIdAsync(Department, cancellationToken);

            return NoContent();
        }
    }
}
