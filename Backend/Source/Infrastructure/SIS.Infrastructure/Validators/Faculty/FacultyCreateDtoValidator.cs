using FluentValidation;
using SIS.Application.DTOs.FacultyDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Faculty
{
    /// <summary>
    /// Validator for the <see cref="FacultyCreateDto"/> class.
    /// Ensures that the data provided for creating a faculty meets the required rules and constraints.
    /// </summary>
    public class FacultyCreateDtoValidator : AbstractValidator<FacultyCreateDto>
    {
        private readonly IFacultyValidator _facultyValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="FacultyCreateDtoValidator"/> class.
        /// </summary>
        /// <param name="facultyValidator">An instance of <see cref="IFacultyValidator"/> to perform custom validation logic.</param>
        public FacultyCreateDtoValidator(IFacultyValidator facultyValidator)
        {
            _facultyValidator = facultyValidator;
            // Define validation rules for each property of the FacultyCreateDto class.

            // The UniId property must not be empty, must be greater than 0,
            RuleFor(f => f.UniId)
                .NotEmpty().WithMessage("University ID is required.")
                .GreaterThan(0).WithMessage("University ID must be greater than 0.")
                .MustAsync(facultyValidator.UniversityExistsAsync).WithMessage("University Id doesn't exist.")
                .DependentRules(() =>
                {
                    // The Name property must not be empty, must be between 3 and 100 characters long,
                    RuleFor(f => f.Name)
                        .NotEmpty().WithMessage("Name is required.")
                        .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.")
                        .MustAsync(BeUniqueFacultyName);

                    // The Code property must not be empty, must be between 2 and 10 characters long,
                    RuleFor(f => f.Code)
                        .NotEmpty().WithMessage("Code is required.")
                        .Length(2, 15).WithMessage("Code must be between 2 and 15 characters.")
                        .MustAsync(BeUniqueFacultyCode);

                    // The DeanId property must not be empty, must be a valid GUID,
                    RuleFor(f => f.DeanId)
                        .NotEmpty().WithMessage("Dean ID is required.")
                        .Length(36, 450).WithMessage("Dean ID must be a valid GUID.")
                        .MustAsync(facultyValidator.BeUniqueDeanId).WithMessage("The specified user is not a dean.");
                });

            // The Address property must not be empty, must be between 5 and 100 characters long,
            RuleFor(f => f.Address)
                .NotEmpty()
                .WithMessage("Address is required.")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.");

            // The PhoneNumber property must not be empty, must be exactly 10 digits long,
            RuleFor(f => f.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits long.")
                .MustAsync(facultyValidator.BeUniqueFacultyPhoneNumber);

            // The IsActive property must not be null,
            RuleFor(f => f.IsActive)
                .NotNull().WithMessage("IsActive is required.");
        }

        private async Task<bool> BeUniqueFacultyName(FacultyCreateDto faculty, string name, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyName(faculty.UniId, name, cancellationToken);
        }

        private async Task<bool> BeUniqueFacultyCode(FacultyCreateDto faculty, string code, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyCode(faculty.UniId, code, cancellationToken);
        }
    }
}
