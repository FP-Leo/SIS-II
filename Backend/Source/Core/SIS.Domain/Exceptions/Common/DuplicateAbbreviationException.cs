namespace SIS.Domain.Exceptions.Common
{
    public class DuplicateAbbreviationException : DuplicateDataException
    {
        public DuplicateAbbreviationException() { }

        public DuplicateAbbreviationException(string entityName) : base($"{entityName} abbreviation already exists.") { }
    }
}
