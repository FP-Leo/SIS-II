using SIS.Domain.Shared;

namespace SIS.Application.DTOs.StudentProfileDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a Student profile.
    /// </summary>
    public class StudentProfileCreateDto
    {

        /// <summary>
        /// Gets or sets the unique identifier of the Student.
        /// </summary>
        public required string UserId;
    }
}
