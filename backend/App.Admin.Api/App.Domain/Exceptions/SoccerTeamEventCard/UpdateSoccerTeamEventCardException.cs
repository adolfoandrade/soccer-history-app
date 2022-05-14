using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeamEventCard
{
    [Serializable]
    public class UpdateSoccerTeamEventCardException : Exception
    {
        public UpdateSoccerTeamEventCardException(string message)
            : base(message)
        {
        }

        public UpdateSoccerTeamEventCardException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected UpdateSoccerTeamEventCardException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
