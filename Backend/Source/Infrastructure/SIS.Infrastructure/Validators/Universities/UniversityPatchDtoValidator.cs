using FluentValidation;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Universities
{
    /// <summary>
    /// Validates the <see cref="UniversityPatchDto"/> for patching university data.
    /// </summary>
    public class UniversityPatchDtoValidator : AbstractValidator<UniversityPatchDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityPatchDtoValidator"/> class.
        /// </summary>
        public UniversityPatchDtoValidator(IUniversityValidator universityValidator)
        {
            /// <summary>
            /// Ensures that the university name is unique and meets length requirements.
            /// </summary>
            RuleFor(u => u.Name)
                .Length(3, 100).WithMessage("Name must be between 5 and 50 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityNameAsync)
                .When(u => !string.IsNullOrEmpty(u.Name), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the university abbreviation is unique and meets length requirements.
            /// </summary>
            RuleFor(u => u.Abbreviation)
                .Length(2, 10).WithMessage("Abbreviation must be between 2 and 10 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityAbbreviationAsync)
                .When(u => !string.IsNullOrEmpty(u.Abbreviation), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the university address meets length requirements.
            /// </summary>
            RuleFor(u => u.Address)
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
                .When(u => !string.IsNullOrEmpty(u.Address), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the university domain is valid and meets format requirements.
            /// </summary>
            RuleFor(x => x.Domain)
                .Matches(@"^(?!-)[A-Za-z0-9-]{2,63}(?<!-)\.(edu|edu\.[a-z]{2,3})$")
                .WithMessage("Domain must be a valid .edu or .edu.xx domain (e.g., example.edu, uni.edu.tr).")
                .When(u => !string.IsNullOrEmpty(u.Domain), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the rector ID is a valid GUID and corresponds to an existing rector.
            /// </summary>
            RuleFor(u => u.RectorId)
                .Length(36, 450).WithMessage("RectorId must be a valid GUID.")
                .MustAsync(universityValidator.BeValidRectorAsync)
                .When(u => !string.IsNullOrEmpty(u.RectorId), ApplyConditionTo.CurrentValidator);
        }
    }
}
