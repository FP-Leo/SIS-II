using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index(nameof(Year), nameof(UniversityId),IsUnique = true)]
    public class GlobalRegistrationPeriod
    {
        public int Id { get; set; }
        public int Year { get; set; }

        // General Student Registration
        public DateTime StudentRegistrationStartDate { get; set; }
        public int StudentRegistrationDuration { get; set; } // in days

        // Course Selection (used for both semesters)
        public DateTime FirstSemesterCourseSelectionDate { get; set; }
        public DateTime SecondSemesterCourseSelectionDate { get; set; }
        public int CourseSelectionDuration { get; set; } // in days, used for both semesters

        // First Semester
        public DateTime FirstSemesterMidTermStartDate { get; set; }
        public DateTime FirstSemesterFinalsStartDate { get; set; }
        public DateTime FirstSemesterMakeUpStartDate { get; set; } // Make-up exams for the first semester

        // Second Semester
        public DateTime SecondSemesterMidTermStartDate { get; set; }
        public DateTime SecondSemesterFinalsStartDate { get; set; }
        public DateTime SecondSemesterMakeUpStartDate { get; set; } // Make-up exams for the second semester

        public int MidTermsDuration { get; set; } // in days, used for both semesters
        public int FinalsDuration { get; set; } // in days, used for both semesters
        public int MakeUpDuration { get; set; } // in days, used for both semesters

        // Navigation Properties
        public int UniversityId { get; set; }
        public required University University { get; set; }
    }
}
