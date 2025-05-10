using FluentValidation;
using SIS.Application.DTOs.FacultyDTOs;
using SIS.Application.Interfaces.Validators;

namespace SIS.Infrastructure.Validators.Faculty
{
    /// <summary>
    /// Validator for the <see cref="FacultyUpdateDto"/> class.
    /// Ensures that the data provided for updating a faculty meets the required rules and constraints.
    /// </summary>
    public class FacultyUpdateDtoValidator : AbstractValidator<FacultyUpdateDto>
    {
        private readonly IFacultyValidator _facultyValidator;
        /// <summary>
        /// Initializes a new instance of the <see cref="FacultyUpdateDtoValidator"/> class.
        /// </summary>
        /// <param name="facultyValidator">An instance of <see cref="IFacultyValidator"/> to perform custom validation logic.</param>
        public FacultyUpdateDtoValidator(IFacultyValidator facultyValidator)
        {
            _facultyValidator = facultyValidator;
            // Define validation rules for each property of the FacultyCreateDto class.

            // The Id property must not be empty, must be greater than 0,
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Faculty ID is required.")
                .GreaterThan(0).WithMessage("Faculty ID must be greater than 0.");

            // The UniId property must not be empty, must be greater than 0,
            RuleFor(f => f.UniId)
                .NotEmpty().WithMessage("University ID is required.")
                .GreaterThan(0).WithMessage("University ID must be greater than 0.")
                .MustAsync(facultyValidator.UniversityExistsAsync).WithMessage("University ID doesn't exist.")
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
                        .Length(36, 450).WithMessage("Dean ID must be a valid GUID.").WithMessage("The specified user is not a dean.")
                        .MustAsync(BeUniqueDeanId);
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
                .MustAsync(BeUniquePhoneNumber);

            // The IsActive property must not be null,
            RuleFor(f => f.IsActive)
                .NotNull().WithMessage("IsActive is required.");
        }

        private async Task<bool> BeUniqueFacultyName(FacultyUpdateDto faculty, string name, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyName(faculty.UniId, faculty.Id, name, cancellationToken);
        }

        private async Task<bool> BeUniqueFacultyCode(FacultyUpdateDto faculty, string code, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyCode(faculty.UniId, faculty.Id, code, cancellationToken);
        }

        private async Task<bool> BeUniqueDeanId(FacultyUpdateDto faculty, string deanId, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueDeanId(deanId, faculty.Id, cancellationToken);
        }

        private async Task<bool> BeUniquePhoneNumber(FacultyUpdateDto faculty, string phoneNumber, CancellationToken cancellationToken)
        {
            return await _facultyValidator.BeUniqueFacultyPhoneNumber(phoneNumber, faculty.Id, cancellationToken);
        }
    }
}
