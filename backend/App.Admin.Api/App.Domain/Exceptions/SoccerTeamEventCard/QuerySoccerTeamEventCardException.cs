using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeamEventCard
{
    [Serializable]
    public class QuerySoccerTeamEventCardException : Exception
    {
        public QuerySoccerTeamEventCardException(string message)
            : base(message)
        {
        }

        public QuerySoccerTeamEventCardException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QuerySoccerTeamEventCardException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
