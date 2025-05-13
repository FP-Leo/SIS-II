using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(StudentId), IsUnique = true)]
    [Index(nameof(ProgramId), nameof(StudentProfileId), IsUnique = true)]
    /// <summary>
    /// Represents the enrollment of a student in an academic program.
    /// </summary>
    public class StudentProgramEnrollment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the program enrollment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the student associated with the program enrollment.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the status of the student (e.g., "Active", "Graduated").
        /// </summary>
        public required string Status { get; set; }

        /// <summary>
        /// Gets or sets the year of the student.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the GPA of the student.
        /// </summary>
        public double GPA { get; set; }

        /// <summary>
        /// Gets or sets the total credits earned by the student.
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// Gets or sets the date the student registered in the academic program.
        /// </summary>
        public DateOnly ProgramRegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the graduation date of the student, if applicable.
        /// </summary>
        public DateOnly? GraduationDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the student profile associated with the program enrollment.
        /// </summary>
        public int StudentProfileId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the academic program associated with the program enrollment.
        /// </summary>
        public int ProgramId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the advisor associated with the program enrollment.
        /// </summary>
        public int AdvisorId { get; set; }

        /// <summary>
        /// Gets or sets the student profile associated with the program enrollment.
        /// </summary>
        public StudentProfile? StudentProfile { get; set; }

        /// <summary>
        /// Gets or sets the academic program associated with the program enrollment.
        /// </summary>
        public AcademicProgram? Program { get; set; }

        /// <summary>
        /// Gets or sets the advisor profile associated with the program enrollment.
        /// </summary>
        public AdvisorProfile? Advisor { get; set; }

        /// <summary>
        /// Gets or sets the list of enrollments associated with the student profile.
        /// </summary>
        public List<StudentCourseEnrollment>? CourseEnrollments { get; set; }
    }
}
