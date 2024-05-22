using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure.Exceptions
{
    public class MissingRequiredDataException : Exception
    {
        public MissingRequiredDataException()
        {
        }

        public MissingRequiredDataException(string message) : base(message)
        {
        }

        public MissingRequiredDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}
