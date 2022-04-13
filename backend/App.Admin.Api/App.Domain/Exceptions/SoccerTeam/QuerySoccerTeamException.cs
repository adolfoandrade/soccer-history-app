using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeam
{
    [Serializable]
    public class QuerySoccerTeamException : Exception
    {
        public QuerySoccerTeamException(string message)
            : base(message)
        {
        }

        public QuerySoccerTeamException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QuerySoccerTeamException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
