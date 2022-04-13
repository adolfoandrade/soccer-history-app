using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Competition
{
    [Serializable]
    public class QueryCompetitionBySeasonException : Exception
    {
        public QueryCompetitionBySeasonException(string message)
            : base(message)
        {
        }

        public QueryCompetitionBySeasonException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryCompetitionBySeasonException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
