using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(Name), nameof(DepartmentId), IsUnique = true)]
    /// <summary>
    /// Represents an academic program in the system.
    /// </summary>
    public class AcademicProgram
    {
        /// <summary>
        /// Gets or sets the unique identifier for the program.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the program.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the program.
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the campus where the program is offered.
        /// </summary>
        public int CampusId { get; set; }

        /// <summary>
        /// Gets or sets the type of the program.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// Gets or sets the enrollment limit for the program.
        /// </summary>
        public int EnrollmentLimit { get; set; }

        /// <summary>
        /// Gets or sets minimum time required to complete the program.
        /// </summary>
        public int MinDuration { get; set; }

        /// <summary>
        /// Gets or sets maximum time required to complete the program.
        /// </summary>
        public int MaxDuration { get; set; }

        /// <summary>
        /// Gets or sets number of credits per semester.
        /// </summary>
        public int SemesterCredits {  get; set; }

        /// <summary>
        /// Gets or sets the total number of credits required to complete the program.
        /// </summary>
        public int TotalCredits { get; set; }

        /// <summary>
        /// Gets or sets the campus where the program is offered.
        /// </summary>
        public CampusBuilding? CampusBuilding { get; set; }

        /// <summary>
        /// Gets or sets the prerequisite programs required for admission.
        /// </summary>
        public List<int>? PrerequisiteProgramIds {  get; set; }

        /// <summary>
        /// Gets or sets the status of the program.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date when the program was created.
        /// </summary>
        public DateOnly CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date when the program was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the department offering the program.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the list of prerequisite courses for this program.
        /// </summary>

        public List<AcademicProgram>? PrerequisitePrograms { get; set; }

        /// <summary>
        /// Gets or sets the department offering the program.
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Gets or sets the exam periods associated with the program.
        /// </summary>
        public List<ExamPeriod>? ExamPeriods { get; set; }

        /// <summary>
        /// Gets or sets the student list enrolled in the program.
        /// </summary>
        public List<StudentProgramEnrollment>? StudentsEnrolled {get; set; }
    }
}
