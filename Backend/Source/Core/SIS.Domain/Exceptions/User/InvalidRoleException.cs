using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.User
{
    public class InvalidRoleException : InvalidInputException
    {
        public InvalidRoleException():base("Invalid role provided.") { }

        public InvalidRoleException(string message) : base(message) { }
    }
}
