using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeamEventGoal
{
    [Serializable]
    public class DeleteSoccerTeamEventGoalsException : Exception
    {
        public DeleteSoccerTeamEventGoalsException(string message)
            : base(message)
        {
        }

        public DeleteSoccerTeamEventGoalsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected DeleteSoccerTeamEventGoalsException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
