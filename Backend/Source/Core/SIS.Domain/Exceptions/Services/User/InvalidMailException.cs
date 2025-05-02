using SIS.Domain.Exceptions.Common;

namespace SIS.Domain.Exceptions.Services.User
{
    public class InvalidMailException : InvalidInputException
    {
        public InvalidMailException() : base("Invalid email provided.") { }
        public InvalidMailException(string message) : base(message) { }
    }
}
