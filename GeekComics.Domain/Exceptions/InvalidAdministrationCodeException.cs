using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekComics.Domain.Exceptions
{
    public class InvalidAdministrationCodeException : Exception
    {
        public InvalidAdministrationCodeException()
        {
        }

        public InvalidAdministrationCodeException(string? message) : base(message)
        {
        }

        public InvalidAdministrationCodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
