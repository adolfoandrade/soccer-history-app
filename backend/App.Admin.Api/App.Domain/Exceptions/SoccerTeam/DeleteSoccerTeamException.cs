using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeam
{
    [Serializable]
    public class DeleteSoccerTeamException : Exception
    {
        public DeleteSoccerTeamException(string message)
            : base(message)
        {
        }

        public DeleteSoccerTeamException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected DeleteSoccerTeamException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
