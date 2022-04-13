using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class QueryByMatchSoccerEventException : Exception
    {
        public QueryByMatchSoccerEventException(string message)
            : base(message)
        {
        }

        public QueryByMatchSoccerEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryByMatchSoccerEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
