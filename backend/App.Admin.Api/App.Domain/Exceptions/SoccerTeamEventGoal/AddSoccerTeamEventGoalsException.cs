using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerTeamEventGoal
{
    [Serializable]
    public class AddSoccerTeamEventGoalsException : Exception
    {
        public AddSoccerTeamEventGoalsException(string message)
            : base(message)
        {
        }

        public AddSoccerTeamEventGoalsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddSoccerTeamEventGoalsException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
