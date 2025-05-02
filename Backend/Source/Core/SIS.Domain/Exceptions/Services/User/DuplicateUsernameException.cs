using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Services.User
{
    public class DuplicateUsernameException : DuplicateDataException
    {
        public DuplicateUsernameException()
            : base("The username is already taken. Please choose a different one.")
        {
        }
        public DuplicateUsernameException(string username)
            : base($"The username '{username}' is already taken. Please choose a different one.")
        {
        }
        public DuplicateUsernameException(string username, Exception innerException)
            : base($"The username '{username}' is already taken. Please choose a different one.", innerException)
        {
        }
    }
}
