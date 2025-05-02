namespace SIS.Domain.Exceptions.Common
{
    public class DuplicateDataException: InvalidInputException
    {
        public DuplicateDataException() : base("Duplicate data found.")
        {
        }
        public DuplicateDataException(string message): base(message)
        {
        }

        public DuplicateDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
