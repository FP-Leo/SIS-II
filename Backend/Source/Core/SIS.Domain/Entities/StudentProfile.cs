using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index("StudentId", IsUnique = true)]
    [Index("Type", "UserId", IsUnique = true)]
    public class StudentProfile
    {
        // Primary Key
        public int Id { get; set; }

        // Properties
        public required int StudentId { get; set; } // Id of user specific to department.
        public required String Type { get; set; } // e.g., "Undergraduate", "Graduate", "PhD"
        public required String Status { get; set; } // e.g., "Active", "Inactive", "Graduated", "Dropped Out"
        public required int Year { get; set; }
        public required double GPA { get; set; }
        public required int Credits { get; set; }
        public required DateOnly DepartmentRegistrationDate { get; set; }
        public DateOnly? GraduationDate { get; set; }

        // Foreign Keys
        public required string UserId { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Properties
        public required User User { get; set; }
        public required Department Department { get; set; }
        public IEnumerable<Course> Courses { get; set; } = [];
    }
}
