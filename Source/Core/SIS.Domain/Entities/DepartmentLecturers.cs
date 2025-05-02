using Microsoft.EntityFrameworkCore;

namespace SIS.Domain.Entities
{
    [Index("DepartmentId, LecturerId, StartDate", IsUnique = true)] // To allow to keep records if the lecturer quits and rejoins the department
    public class DepartmentLecturers
    {
        // Primary Key
        public int Id { get; set; }

        // Properties
        public required string Position { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; } // Nullable to allow for current positions
        public required int Hours { get; set; } // total assigned hours for this department

        // Foreign Keys
        public required int DepartmentId { get; set; }
        public required string LecturerId { get; set; }

        // Navigation Properties
        public required Department Department { get; set; }
        public required User Lecturer { get; set; }
    }
}
