using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class QueryBySeasonSoccerEventException : Exception
    {
        public QueryBySeasonSoccerEventException(string message)
            : base(message)
        {
        }

        public QueryBySeasonSoccerEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryBySeasonSoccerEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
