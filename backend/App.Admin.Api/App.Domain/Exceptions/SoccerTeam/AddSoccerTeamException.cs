using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeam
{
    [Serializable]
    public class AddSoccerTeamException : Exception
    {
        public AddSoccerTeamException(string message)
            : base(message)
        {
        }

        public AddSoccerTeamException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddSoccerTeamException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
