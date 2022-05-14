using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeamEventCard
{
    [Serializable]
    public class AddSoccerTeamEventCardException : Exception
    {
        public AddSoccerTeamEventCardException(string message)
            : base(message)
        {
        }

        public AddSoccerTeamEventCardException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddSoccerTeamEventCardException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
