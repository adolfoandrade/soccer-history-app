using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class QueryMatchException : Exception
    {
        public QueryMatchException(string message)
            : base(message)
        {
        }

        public QueryMatchException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryMatchException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
