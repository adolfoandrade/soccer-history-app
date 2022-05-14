using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeamEventGoal
{
    [Serializable]
    public class UpdateSoccerTeamEventGoalsException : Exception
    {
        public UpdateSoccerTeamEventGoalsException(string message)
            : base(message)
        {
        }

        public UpdateSoccerTeamEventGoalsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected UpdateSoccerTeamEventGoalsException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
