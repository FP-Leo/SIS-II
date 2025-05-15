using SIS.Domain.Shared;

namespace SIS.Application.DTOs.StudentProfileDTOs
{
    public class StudentProfilePatchDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Student profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the default program identifier for the student profile.
        /// </summary>
        public int? DefaultProgramId { get; set; }
    }
}
