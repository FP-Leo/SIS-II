namespace SIS.Application.DTOs.StudentProfileDTOs 
{ 
    /// <summary>
    /// Data Transfer Object (DTO) for retrieving Student profile information.
    /// </summary>
    public class StudentProfileGetDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Student profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the Student.
        /// </summary>
        public required string UserId;


        /// <summary>
        /// Gets or sets the default program identifier for the student profile.
        /// </summary>
        public int? DefaultProgramId { get; set; }
    }
}
