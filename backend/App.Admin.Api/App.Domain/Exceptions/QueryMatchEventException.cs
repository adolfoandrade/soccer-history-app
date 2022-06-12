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
    public class QueryMatchEventException : Exception
    {
        public QueryMatchEventException(string message)
            : base(message)
        {
        }

        public QueryMatchEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryMatchEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
