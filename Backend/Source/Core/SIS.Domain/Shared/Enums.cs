namespace SIS.Domain.Shared
{
    public enum StudentType
    {
        FullTime,
        International,
        Online,
        Exchange,
    }

    public enum StudentStatus
    {
        Active,
        Inactive,
        Graduated,
        Suspended,
        Expelled,
        DroppedOut
    }

    public enum LecturerType
    {
        Professor,
        AssociateProfessor,
        AssistantProfessor,
        Lecturer,
        AssistantLecturer,
    }

    public enum Level
    {
        Undergraduate,
        Postgraduate
    }

    public enum CourseType
    {
        Core,
        Elective
    }

    public enum DeliveryMethod
    {
        Online,
        InPerson,
        Hybrid
    }

    public enum EnrollmentStatus
    {
        Enrolled,
        Waitlisted,
        Dropped,
        Completed,
        Retaking,
        Failed
    }

    //// EVENTS

    // Exam
    public enum AssessmentType
    {
        Midterm,
        Final,
        Suplementary,
        Makeup,
        OneCourse,
        Project,
        Quiz,
        Assignment,
    }

    // Holiday

    public enum HolidayType
    {
        National,
        Religious,
        Regional,
        Academic,
        Cultural,
        Administrative,     // Administrative holidays or days off (e.g., Office closures, staff retreats)
    }

    public enum AcademicEventStatus
    {
        Scheduled,
        Ongoing,
        Completed,
        Cancelled,
        Postponed
    }
}
