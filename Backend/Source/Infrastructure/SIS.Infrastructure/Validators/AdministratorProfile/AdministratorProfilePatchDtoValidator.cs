using FluentValidation;
using SIS.Application.DTOs.AdministratorProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.AdministratorProfile
{
    public class AdministratorProfilePatchDtoValidator : AbstractValidator<AdministratorProfilePatchDto>
    {
        private readonly IAdministratorProfileValidator _administratorProfileValidator;

        public AdministratorProfilePatchDtoValidator(IAdministratorProfileValidator administratorProfileValidator)
        {
            _administratorProfileValidator = administratorProfileValidator;

            RuleFor(ap => ap.Id)
                .NotEmpty().WithMessage("Profile ID is required.")
                .GreaterThan(0).WithMessage("Profile ID must be greater than 0.")
                .MustAsync(_administratorProfileValidator.IsValidProfile);

            RuleFor(ap => ap.DepartmentId)
                .NotNull().WithMessage("Department ID is required")
                .NotEmpty().WithMessage("Department ID is required")
                .MustAsync(_administratorProfileValidator.IsValidDepartment)
                .MustAsync(IsUnique).WithMessage("The administrator profile already exists.")
                .When(ap => ap.DepartmentId != null);
        }

        private async Task<bool> IsUnique(AdministratorProfilePatchDto administratorProfile, int? depID, CancellationToken cancellationToken)
        {
            if (administratorProfile == null || depID == null) throw new ApplicationException("The specified profile or department ID is null.");

            return await _administratorProfileValidator.IsUniqueProfile(administratorProfile.Id, depID!.Value, cancellationToken);
        }
    }
}
