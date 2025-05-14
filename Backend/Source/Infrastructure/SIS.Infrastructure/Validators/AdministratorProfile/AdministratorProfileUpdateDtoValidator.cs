using FluentValidation;
using SIS.Application.DTOs.AdministratorProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.AdministratorProfile
{
    public class AdministratorProfileUpdateDtoValidator: AbstractValidator<AdministratorProfileUpdateDto>
    {
        private readonly IAdministratorProfileValidator _administratorProfileValidator;
        public AdministratorProfileUpdateDtoValidator(IAdministratorProfileValidator administratorProfileValidator)
        {
            _administratorProfileValidator = administratorProfileValidator;

            RuleFor(ap => ap.Id)
                .NotNull().WithMessage("Profile ID is required.")
                .NotEmpty().WithMessage("Profile ID is required.")
                .MustAsync(_administratorProfileValidator.IsValidProfile);

            RuleFor(ap => ap.DepartmentId)
                .NotNull().WithMessage("Department ID is required")
                .NotEmpty().WithMessage("Department ID is required")
                .MustAsync(_administratorProfileValidator.IsValidDepartment);

            RuleFor(ap => ap)
                .MustAsync(IsUniqueProfile).WithMessage("The administrator profile already exists.");
        }

        private Task<bool> IsUniqueProfile(AdministratorProfileUpdateDto administratorProfile, CancellationToken cancellationToken)
        {
            return _administratorProfileValidator.IsUniqueProfile(administratorProfile.Id, administratorProfile.DepartmentId, cancellationToken);
        }
    }
}
