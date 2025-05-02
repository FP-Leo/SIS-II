namespace SIS.Domain.Exceptions.Common
{
    public class DuplicateNameException : DuplicateDataException
    {
        public DuplicateNameException() { }
        public DuplicateNameException(string entityName) : base($"{entityName} name already exists.") { }
    }
}