using FluentValidation;
using SIS.Application.DTOs.DepartmentDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Department
{
    /// <summary>
    /// Validator for the <see cref="DepartmentPatchDto"/> class.
    /// Ensures that the data provided for creating a department meets the required rules and constraints.
    /// </summary>
    public class DepartmentPatchDtoValidator : AbstractValidator<DepartmentPatchDto>
    {
        private readonly IDepartmentValidator _departmentValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentPatchDtoValidator"/> class.
        /// </summary>
        /// <param name="departmentValidator">An instance of <see cref="IDepartmentValidator"/> to perform custom validation logic.</param>

        public DepartmentPatchDtoValidator(IDepartmentValidator departmentValidator)
        {
            _departmentValidator = departmentValidator;

            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Department ID is required.")
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.")
                .MustAsync(_departmentValidator.ValidateDepartmentId);

            RuleFor(d => d.FacultyId)
                .NotNull().WithMessage("Faculty ID is required to patch itself or any of the following fields: 'name', 'code', 'head of department'.")
                .NotEmpty().WithMessage("Faculty ID is required to patch itself or any of the following fields: 'name', 'code', 'head of department'.")
                .GreaterThan(0).WithMessage("Faculty ID must be greater than 0. It is required to patch any of the following fields: 'name', 'code', 'head of department'.")
                .MustAsync(_departmentValidator.FacultyExistsAsync).WithMessage("Faculty Id doesn't exist. It is required to patch itself or any of the following fields: 'name', 'code', 'head of department'.")
                .When(d =>  d.FacultyId != null || !string.IsNullOrEmpty(d.Name) || !string.IsNullOrEmpty(d.Code) || !string.IsNullOrEmpty(d.HeadOfDepartmentId), ApplyConditionTo.CurrentValidator)
                .DependentRules(() =>
                {
                    // The Name property must not be empty, must be between 3 and 100 characters long,
                    RuleFor(d => d.Name)
                        .NotEmpty().WithMessage("Name is required.")
                        .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.")
                        .MustAsync(BeUniqueDepartment)
                        .When(d => !string.IsNullOrEmpty(d.Name), ApplyConditionTo.CurrentValidator);

                    // The Code property must not be empty, must be between 2 and 10 characters long,
                    RuleFor(d => d.Code)
                        .NotEmpty().WithMessage("Code is required.")
                        .Length(2, 15).WithMessage("Code must be between 2 and 15 characters.")
                        .MustAsync(BeUniqueCode)
                        .When(d => !string.IsNullOrEmpty(d.Code), ApplyConditionTo.CurrentValidator);

                    // The DeanId property must not be empty, must be a valid GUID,
                    RuleFor(d => d.HeadOfDepartmentId)
                        .NotEmpty().WithMessage("HoD Id is required.")
                        .Length(36, 450).WithMessage("HoD Id must be a valid GUID.")
                        .MustAsync(BeUniqueHod).WithMessage("The specified user does not have the HoD role.")
                        .When(d => !string.IsNullOrEmpty(d.HeadOfDepartmentId), ApplyConditionTo.CurrentValidator);
                });

            // The Address property must not be empty, must be between 5 and 100 characters long,
            RuleFor(d => d.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
                .When(d => !string.IsNullOrEmpty(d.Address), ApplyConditionTo.CurrentValidator);

            // The PhoneNumber property must not be empty, must be exactly 10 digits long,
            RuleFor(d => d.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits long.")
                .MustAsync(BeUniquePhoneNumber)
                .When(d => !string.IsNullOrEmpty(d.PhoneNumber), ApplyConditionTo.CurrentValidator);

            RuleFor(d => d.IsActive)
                .NotNull().WithMessage("IsActive is required.")
                .Must(x => x == true || x == false).WithMessage("IsActive must be a boolean value.")
                .When(d => d.IsActive != null, ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> BeUniqueDepartment(DepartmentPatchDto department, string name, CancellationToken cancellationToken)
        {
            return await _departmentValidator.BeUniqueDepartmentName(name, department.Id, department.FacultyId!.Value, cancellationToken);
        }

        private async Task<bool> BeUniqueCode(DepartmentPatchDto department, string code, CancellationToken cancellationToken)
        {
            return await _departmentValidator.BeUniqueDepartmentCode(code, department.Id, department.FacultyId!.Value, cancellationToken);
        }

        private async Task<bool> BeUniqueHod(DepartmentPatchDto department, string hodId, CancellationToken cancellationToken)
        {
            return await _departmentValidator.BeUniqueHeadOfDepartmentId(hodId, department.Id, cancellationToken);
        }

        private async Task<bool> BeUniquePhoneNumber(DepartmentPatchDto department, string phoneNumber, CancellationToken cancellationToken)
        {
            return await _departmentValidator.BeUniqueDepartmentPhoneNumber(phoneNumber, department.Id, cancellationToken);
        }
    }
}
