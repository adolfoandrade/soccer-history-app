using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

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
