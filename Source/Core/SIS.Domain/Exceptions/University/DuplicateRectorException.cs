using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.University
{
    public class DuplicateRectorException : DuplicateDataException
    {
        public DuplicateRectorException():base("Rector not found.") { }
    }
}