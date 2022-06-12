using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Exceptions
{
    [Serializable]
    public class AddMatchEventException : Exception
    {
        public AddMatchEventException(string message)
            : base(message)
        {
        }

        public AddMatchEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddMatchEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
