using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class QuerySoccerEventException : Exception
    {
        public QuerySoccerEventException(string message)
            : base(message)
        {
        }

        public QuerySoccerEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QuerySoccerEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
