using FluentValidation;
using SIS.Application.DTOs.AdvisorProfileDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.AdvisorProfile
{
    /// <summary>
    /// Validator for the <see cref="AdvisorProfileCreateDto"/> class.
    /// Ensures that the data provided for creating an Advisor profile meets the required rules and constraints.
    /// </summary>
    public class AdvisorProfileCreateDtoValidator: AbstractValidator<AdvisorProfileCreateDto>
    {
        private readonly IAdvisorProfileValidator _AdvisorProfileValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvisorProfileCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="AdvisorProfileValidator">An instance of <see cref="IAdvisorProfileValidator"/> to perform custom validation logic.</param>
        public AdvisorProfileCreateDtoValidator(IAdvisorProfileValidator AdvisorProfileValidator)
        {
            _AdvisorProfileValidator = AdvisorProfileValidator;

            RuleFor(ap => ap.UserId)
                .NotNull().WithMessage("User ID is required.")
                .NotEmpty().WithMessage("User ID is required.")
                .Length(36, 450).WithMessage("User Id must be a valid GUID.")
                .MustAsync(_AdvisorProfileValidator.IsValidAdvisor);

            RuleFor(ap => ap.DepartmentId)
                .NotNull().WithMessage("Department ID is required")
                .NotEmpty().WithMessage("Department ID is required")
                .MustAsync(_AdvisorProfileValidator.IsValidDepartment);

            RuleFor(ap => ap)
                .MustAsync(IsUniqueProfile).WithMessage("The Advisor profile already exists.");
        }

        private Task<bool> IsUniqueProfile(AdvisorProfileCreateDto AdvisorProfile, CancellationToken cancellationToken)
        {
            return _AdvisorProfileValidator.IsUniqueProfile(AdvisorProfile.UserId, AdvisorProfile.DepartmentId, cancellationToken);
        }
    }
}
