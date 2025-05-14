using FluentValidation;
using SIS.Application.DTOs.AdministratorProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.AdministratorProfile
{
    /// <summary>
    /// Validator for the <see cref="AdministratorProfileCreateDto"/> class.
    /// Ensures that the data provided for creating an administrator profile meets the required rules and constraints.
    /// </summary>
    public class AdministratorProfileCreateDtoValidator: AbstractValidator<AdministratorProfileCreateDto>
    {
        private readonly IAdministratorProfileValidator _administratorProfileValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministratorProfileCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="administratorProfileValidator">An instance of <see cref="IAdministratorProfileValidator"/> to perform custom validation logic.</param>
        public AdministratorProfileCreateDtoValidator(IAdministratorProfileValidator administratorProfileValidator)
        {
            _administratorProfileValidator = administratorProfileValidator;

            RuleFor(ap => ap.UserId)
                .NotNull().WithMessage("User ID is required.")
                .NotEmpty().WithMessage("User ID is required.")
                .Length(36, 450).WithMessage("User Id must be a valid GUID.")
                .MustAsync(_administratorProfileValidator.IsValidAdministrator);

            RuleFor(ap => ap.DepartmentId)
                .NotNull().WithMessage("Department ID is required")
                .NotEmpty().WithMessage("Department ID is required")
                .MustAsync(_administratorProfileValidator.IsValidDepartment);

            RuleFor(ap => ap)
                .MustAsync(IsUniqueProfile).WithMessage("The administrator profile already exists.");
        }

        private Task<bool> IsUniqueProfile(AdministratorProfileCreateDto administratorProfile, CancellationToken cancellationToken)
        {
            return _administratorProfileValidator.IsUniqueProfile(administratorProfile.UserId, administratorProfile.DepartmentId, cancellationToken);
        }
    }
}
