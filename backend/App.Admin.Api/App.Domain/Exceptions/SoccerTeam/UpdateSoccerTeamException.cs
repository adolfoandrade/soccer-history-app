using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeam
{
    [Serializable]
    public class UpdateSoccerTeamException : Exception
    {
        public UpdateSoccerTeamException(string message)
            : base(message)
        {
        }

        public UpdateSoccerTeamException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected UpdateSoccerTeamException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
