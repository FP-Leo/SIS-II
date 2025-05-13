using FluentValidation;
using SIS.Application.DTOs.DepartmentDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Department
{
    /// <summary>
    /// Validator for the <see cref="DepartmentCreateDto"/> class.
    /// Ensures that the data provided for creating a department meets the required rules and constraints.
    /// </summary>
    public class DepartmentCreateDtoValidator: AbstractValidator<DepartmentCreateDto>
    {
        private readonly IDepartmentValidator _departmentValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="departmentValidator">An instance of <see cref="IDepartmentValidator"/> to perform custom validation logic.</param>

        public DepartmentCreateDtoValidator(IDepartmentValidator departmentValidator)
        {
            _departmentValidator = departmentValidator;

            RuleFor(d => d.FacultyId)
                .NotEmpty().WithMessage("Faculty ID is required.")
                .GreaterThan(0).WithMessage("Faculty ID must be greater than 0.")
                .MustAsync(_departmentValidator.FacultyExistsAsync).WithMessage("Faculty Id doesn't exist.")
                .DependentRules(() =>
                {
                    // The Name property must not be empty, must be between 3 and 100 characters long,
                    RuleFor(d => d.Name)
                        .NotEmpty().WithMessage("Name is required.")
                        .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.")
                        .MustAsync(BeUniqueDepartment);

                    // The Code property must not be empty, must be between 2 and 10 characters long,
                    RuleFor(d => d.Code)
                        .NotEmpty().WithMessage("Code is required.")
                        .Length(2, 15).WithMessage("Code must be between 2 and 15 characters.")
                        .MustAsync(BeUniqueCode);

                    // The DeanId property must not be empty, must be a valid GUID,
                    RuleFor(d => d.HeadOfDepartmentId)
                        .NotEmpty().WithMessage("HoD Id is required.")
                        .Length(36, 450).WithMessage("HoD Id must be a valid GUID.")
                        .MustAsync(_departmentValidator.BeUniqueHeadOfDepartmentId).WithMessage("The specified user does not have the HoD role.");
                });

            // The Address property must not be empty, must be between 5 and 100 characters long,
            RuleFor(d => d.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.");

            // The PhoneNumber property must not be empty, must be exactly 10 digits long,
            RuleFor(d => d.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits long.")
                .MustAsync(_departmentValidator.BeUniqueDepartmentPhoneNumber);

            RuleFor(d => d.IsActive)
                .NotNull().WithMessage("IsActive is required.")
                .Must(x => x == true || x == false).WithMessage("IsActive must be a boolean value.");
        }

        private async Task<bool> BeUniqueDepartment(DepartmentCreateDto department, string name, CancellationToken cancellationToken)
        {
            return await _departmentValidator.BeUniqueDepartmentName(name, department.FacultyId, cancellationToken);
        }

        private async Task<bool> BeUniqueCode(DepartmentCreateDto department, string code, CancellationToken cancellationToken)
        {
            return await _departmentValidator.BeUniqueDepartmentCode(code, department.FacultyId, cancellationToken);
        }
    }
}
