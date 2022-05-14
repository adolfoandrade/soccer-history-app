using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeamEventCard
{
    [Serializable]
    public class DeleteSoccerTeamEventCardException : Exception
    {
        public DeleteSoccerTeamEventCardException(string message)
            : base(message)
        {
        }

        public DeleteSoccerTeamEventCardException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected DeleteSoccerTeamEventCardException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
