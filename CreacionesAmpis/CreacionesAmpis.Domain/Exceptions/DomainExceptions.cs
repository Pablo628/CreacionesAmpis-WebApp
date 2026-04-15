using System;
using System.Collections.Generic;
using System.Text;

namespace CreacionesAmpis.Domain.Exceptions
{
    using System;

    namespace PrivateBlog.Domain.Exceptions
    {
        public class DomainException : Exception
        {
            public DomainException(string message) : base(message)
            {
            }
        }
    }
}
