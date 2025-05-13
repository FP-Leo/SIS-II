using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(CourseInstanceId), nameof(Name), IsUnique = true)]
    /// <summary>
    /// Represents an assessment in the system.
    /// </summary>
    public class Assessment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the assessment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the assessment (e.g., "Midterm Exam", "Final Exam", "Project" etc.).
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the assessment type (e.g., "Midterm", "Final", "Project").
        /// </summary>
        public AssessmentType Type { get; set; }

        /// <summary>
        /// Gets or sets the start time of the assessment.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end time of the assessment.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the notes or additional information about the assessment.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the weight percentage of the assessment in the overall course grade.
        /// </summary>
        public int WeightPercentage { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the course instance associated with this assessment.
        /// </summary>
        public int CourseInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the course instance associated with this assessment.
        /// </summary>
        public CourseInstance? CourseInstance { get; set; }
    }
}
