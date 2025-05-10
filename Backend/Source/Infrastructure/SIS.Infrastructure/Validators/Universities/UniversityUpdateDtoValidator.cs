using FluentValidation;
using SIS.Application.DTOs.UniversityDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Universities
{
    /// <summary>
    /// Validates the <see cref="UniversityUpdateDto"/> for updating university data.
    /// </summary>
    public class UniversityUpdateDtoValidator : AbstractValidator<UniversityUpdateDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityUpdateDtoValidator"/> class.
        /// </summary>
        public UniversityUpdateDtoValidator(IUniversityValidator universityValidator)
        {
            /// <summary>
            /// Ensures that the university name is not empty, has a valid length, and is unique.
            /// </summary>
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 100).WithMessage("Name must be between 5 and 50 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityNameAsync);

            /// <summary>
            /// Ensures that the university abbreviation is not empty, has a valid length, and is unique.
            /// </summary>
            RuleFor(u => u.Abbreviation)
                .NotEmpty().WithMessage("Abbreviation is required.")
                .Length(2, 10).WithMessage("Abbreviation must be between 2 and 10 characters.")
                .MustAsync(universityValidator.BeUniqueUniversityAbbreviationAsync);

            /// <summary>
            /// Ensures that the university address is not empty and has a valid length.
            /// </summary>
            RuleFor(u => u.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.");

            /// <summary>
            /// Ensures that the rector ID is not empty, has a valid length, and corresponds to an existing rector.
            /// </summary>
            RuleFor(u => u.RectorId)
                .NotEmpty().WithMessage("RectorId is required.")
                .Length(36, 450).WithMessage("RectorId must be a valid GUID.")
                .MustAsync(universityValidator.BeValidRectorAsync);
        }
    }
}
