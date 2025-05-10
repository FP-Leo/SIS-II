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
        private readonly IUniversityValidator _universityValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityUpdateDtoValidator"/> class.
        /// </summary>
        public UniversityUpdateDtoValidator(IUniversityValidator universityValidator)
        {
            _universityValidator = universityValidator;

            /// <summary>
            /// Ensures that the university ID is not empty and greater than 0.
            /// </summary>
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            /// <summary>
            /// Ensures that the university name is not empty, has a valid length, and is unique.
            /// </summary>
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 100).WithMessage("Name must be between 5 and 50 characters.")
                .MustAsync(BeUniqueUniversityNameAsync);

            /// <summary>
            /// Ensures that the university abbreviation is not empty, has a valid length, and is unique.
            /// </summary>
            RuleFor(u => u.Abbreviation)
                .NotEmpty().WithMessage("Abbreviation is required.")
                .Length(2, 10).WithMessage("Abbreviation must be between 2 and 10 characters.")
                .MustAsync(BeUniqueUniversityAbbreviationAsync);

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
                .MustAsync(BeValidRectorAsync);
        }

        private async Task<bool> BeUniqueUniversityNameAsync(UniversityUpdateDto university, string name, CancellationToken cancellationToken)
        {
            return await _universityValidator.BeUniqueUniversityNameAsync(name, university.Id, cancellationToken);
        }

        private async Task<bool> BeUniqueUniversityAbbreviationAsync(UniversityUpdateDto university, string abbreviation, CancellationToken cancellationToken)
        {
            return await _universityValidator.BeUniqueUniversityAbbreviationAsync(abbreviation, university.Id, cancellationToken);
        }

        private async Task<bool> BeValidRectorAsync(UniversityUpdateDto university, string rectorId, CancellationToken cancellationToken)
        {
            return await _universityValidator.BeValidRectorAsync(rectorId, university.Id, cancellationToken);
        }
    }
}
