using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure.Exceptions
{
    public class InvalidDataFormatException : Exception
    {
        public InvalidDataFormatException()
        {
        }

        public InvalidDataFormatException(string message) : base(message)
        {
        }

        public InvalidDataFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
