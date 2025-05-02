namespace SIS.Domain.Entities
{
    public class LecturerProfile
    {
        // Primary Key
        public int Id { get; set; }

        // Properties
        public required string Title { get; set; } // e.g., "Professor", "Associate Professor", "Assistant Professor", "Lecturer"

        // Foreign Key
        public required string LecturerId;

        // Navigation Property
        public required User User { get; set; }
    }
}
