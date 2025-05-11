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
}
