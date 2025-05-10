using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Exceptions.Common
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate PhoneNumber is detected.
    /// </summary>
    public class DuplicatePhoneNumberException : DuplicateDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatePhoneNumberException"/> class with a default message.
        /// </summary>
        public DuplicatePhoneNumberException() : base($"Phone number already exists in the database.") { }
    }
}
