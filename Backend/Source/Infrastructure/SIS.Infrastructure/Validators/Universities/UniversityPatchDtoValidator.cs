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
        private readonly IUniversityValidator _universityValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityPatchDtoValidator"/> class.
        /// </summary>
        public UniversityPatchDtoValidator(IUniversityValidator universityValidator)
        {
            _universityValidator = universityValidator;

            /// <summary>
            /// Ensures that the university ID is not empty and greater than 0.
            /// </summary>
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            /// <summary>
            /// Ensures that the university name is unique and meets length requirements.
            /// </summary>
            RuleFor(u => u.Name)
                .Length(3, 100).WithMessage("Name must be between 5 and 50 characters.")
                .MustAsync(BeUniqueUniversityNameAsync)
                .When(u => !string.IsNullOrEmpty(u.Name), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the university abbreviation is unique and meets length requirements.
            /// </summary>
            RuleFor(u => u.Abbreviation)
                .Length(2, 10).WithMessage("Abbreviation must be between 2 and 10 characters.")
                .MustAsync(BeUniqueUniversityAbbreviationAsync)
                .When(u => !string.IsNullOrEmpty(u.Abbreviation), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the university address meets length requirements.
            /// </summary>
            RuleFor(u => u.Address)
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.")
                .When(u => !string.IsNullOrEmpty(u.Address), ApplyConditionTo.CurrentValidator);

            /// <summary>
            /// Ensures that the rector ID is a valid GUID and corresponds to an existing rector.
            /// </summary>
            RuleFor(u => u.RectorId)
                .Length(36, 450).WithMessage("RectorId must be a valid GUID.")
                .MustAsync(BeValidRectorAsync)
                .When(u => !string.IsNullOrEmpty(u.RectorId), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> BeUniqueUniversityNameAsync(UniversityPatchDto university, string name, CancellationToken cancellationToken)
        {
            return await _universityValidator.BeUniqueUniversityNameAsync(name, university.Id, cancellationToken);
        }

        private async Task<bool> BeUniqueUniversityAbbreviationAsync(UniversityPatchDto university, string abbreviation, CancellationToken cancellationToken)
        {
            return await _universityValidator.BeUniqueUniversityAbbreviationAsync(abbreviation, university.Id, cancellationToken);
        }

        private async Task<bool> BeValidRectorAsync(UniversityPatchDto university, string rectorId, CancellationToken cancellationToken)
        {
            return await _universityValidator.BeValidRectorAsync(rectorId, university.Id, cancellationToken);
        }
    }
}
