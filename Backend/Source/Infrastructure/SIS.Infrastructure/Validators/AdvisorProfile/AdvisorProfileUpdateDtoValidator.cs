using FluentValidation;
using SIS.Application.DTOs.AdvisorProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.AdvisorProfile
{
    public class AdvisorProfileUpdateDtoValidator: AbstractValidator<AdvisorProfileUpdateDto>
    {
        private readonly IAdvisorProfileValidator _advisorProfileValidator;
        public AdvisorProfileUpdateDtoValidator(IAdvisorProfileValidator advisorProfileValidator)
        {
            _advisorProfileValidator = advisorProfileValidator;

            RuleFor(ap => ap.Id)
                .NotNull().WithMessage("Profile ID is required.")
                .NotEmpty().WithMessage("Profile ID is required.")
                .MustAsync(_advisorProfileValidator.IsValidProfile);

            RuleFor(ap => ap.DepartmentId)
                .NotNull().WithMessage("Department ID is required")
                .NotEmpty().WithMessage("Department ID is required")
                .MustAsync(_advisorProfileValidator.IsValidDepartment);

            RuleFor(ap => ap)
                .MustAsync(IsUniqueProfile).WithMessage("The Advisor profile already exists.");
        }

        private Task<bool> IsUniqueProfile(AdvisorProfileUpdateDto AdvisorProfile, CancellationToken cancellationToken)
        {
            return _advisorProfileValidator.IsUniqueProfile(AdvisorProfile.Id, AdvisorProfile.DepartmentId, cancellationToken);
        }
    }
}
