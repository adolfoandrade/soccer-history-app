using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Exceptions.Statistic
{
    [Serializable]
    public class QueryEventTimeStatisticException : Exception
    {
        public QueryEventTimeStatisticException(string message)
            : base(message)
        {
        }

        public QueryEventTimeStatisticException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryEventTimeStatisticException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
