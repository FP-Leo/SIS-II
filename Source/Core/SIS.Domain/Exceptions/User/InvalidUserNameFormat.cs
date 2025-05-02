using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.User
{
    public class InvalidUserNameFormatException : InvalidInputException
    {
        public InvalidUserNameFormatException(): base("Invalid user name format provided.")
        {
        }

        public InvalidUserNameFormatException(string message) : base(message)
        {
        }
    }
}