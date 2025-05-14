using FluentValidation;
using SIS.Application.DTOs.AdvisorProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.AdvisorProfile
{
    public class AdvisorProfilePatchDtoValidator : AbstractValidator<AdvisorProfilePatchDto>
    {
        private readonly IAdvisorProfileValidator _AdvisorProfileValidator;

        public AdvisorProfilePatchDtoValidator(IAdvisorProfileValidator AdvisorProfileValidator)
        {
            _AdvisorProfileValidator = AdvisorProfileValidator;

            RuleFor(ap => ap.Id)
                .NotEmpty().WithMessage("Profile ID is required.")
                .GreaterThan(0).WithMessage("Profile ID must be greater than 0.")
                .MustAsync(_AdvisorProfileValidator.IsValidProfile);

            RuleFor(ap => ap.DepartmentId)
                .NotNull().WithMessage("Department ID is required")
                .NotEmpty().WithMessage("Department ID is required")
                .MustAsync(_AdvisorProfileValidator.IsValidDepartment)
                .MustAsync(IsUnique).WithMessage("The Advisor profile already exists.")
                .When(ap => ap.DepartmentId != null);
        }

        private async Task<bool> IsUnique(AdvisorProfilePatchDto AdvisorProfile, int? depID, CancellationToken cancellationToken)
        {
            if (AdvisorProfile == null || depID == null) throw new ApplicationException("The specified profile or department ID is null.");

            return await _AdvisorProfileValidator.IsUniqueProfile(AdvisorProfile.Id, depID!.Value, cancellationToken);
        }
    }
}
