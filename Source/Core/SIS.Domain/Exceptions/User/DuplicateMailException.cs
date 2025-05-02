using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.User
{
    public class DuplicateMailException : DuplicateDataException
    {
        public DuplicateMailException(string schoolMail) : base($"The school mail '{schoolMail}' already exists.")
        {
        }
        public DuplicateMailException(string schoolMail, Exception innerException) : base($"The school mail '{schoolMail}' already exists.", innerException)
        {
        }
    }
}
