using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    /// <summary>
    /// Represents the global registration period for a university.
    /// </summary>
    [Index(nameof(Year), nameof(UniversityId), IsUnique = true)]
    public class GlobalRegistrationPeriod
    {
        /// <summary>
        /// Gets or sets the unique identifier for the registration period.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the year of the registration period.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the start date for student registration.
        /// </summary>
        public DateTime StudentRegistrationStartDate { get; set; }

        /// <summary>
        /// Gets or sets the duration of student registration in days.
        /// </summary>
        public int StudentRegistrationDuration { get; set; }

        /// <summary>
        /// Gets or sets the start date for first semester course selection.
        /// </summary>
        public DateTime FirstSemesterCourseSelectionDate { get; set; }

        /// <summary>
        /// Gets or sets the start date for second semester course selection.
        /// </summary>
        public DateTime SecondSemesterCourseSelectionDate { get; set; }

        /// <summary>
        /// Gets or sets the duration of course selection in days.
        /// </summary>
        public int CourseSelectionDuration { get; set; }

        /// <summary>
        /// Gets or sets the start date for first semester midterms.
        /// </summary>
        public DateTime FirstSemesterMidTermStartDate { get; set; }

        /// <summary>
        /// Gets or sets the start date for first semester finals.
        /// </summary>
        public DateTime FirstSemesterFinalsStartDate { get; set; }

        /// <summary>
        /// Gets or sets the start date for first semester make-up exams.
        /// </summary>
        public DateTime FirstSemesterMakeUpStartDate { get; set; }

        /// <summary>
        /// Gets or sets the start date for second semester midterms.
        /// </summary>
        public DateTime SecondSemesterMidTermStartDate { get; set; }

        /// <summary>
        /// Gets or sets the start date for second semester finals.
        /// </summary>
        public DateTime SecondSemesterFinalsStartDate { get; set; }

        /// <summary>
        /// Gets or sets the start date for second semester make-up exams.
        /// </summary>
        public DateTime SecondSemesterMakeUpStartDate { get; set; }

        /// <summary>
        /// Gets or sets the duration of midterms in days.
        /// </summary>
        public int MidTermsDuration { get; set; }

        /// <summary>
        /// Gets or sets the duration of finals in days.
        /// </summary>
        public int FinalsDuration { get; set; }

        /// <summary>
        /// Gets or sets the duration of make-up exams in days.
        /// </summary>
        public int MakeUpDuration { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the university associated with the registration period.
        /// </summary>
        public int UniversityId { get; set; }

        /// <summary>
        /// Gets or sets the university associated with the registration period.
        /// </summary>
        public required University University { get; set; }
    }
}
