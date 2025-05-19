using SIS.Domain.Shared;

namespace SIS.Application.DTOs.CourseInstanceDTOs
{
    /// <summary>
    /// Represents the data transfer object for updating an existing course offering.
    /// </summary>
    public class CourseInstanceUpdateDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the course offering.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the enrollment limit for the course offering.
        /// </summary>
        public int? EnrollmentLimit { get; set; }

        /// <summary>
        /// Gets or sets the delivery method for the course offering (e.g., online, in-person).
        /// </summary>
        public DeliveryMethod DeliveryMethod { get; set; }

        /// <summary>
        /// Gets or sets the required attendance percentage for the course offering.
        /// </summary>
        public int AttendancePercentage { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the lecturer assignment associated with this offering.
        /// </summary>
        public int LecturerAssignmentId { get; set; }
    }
}
