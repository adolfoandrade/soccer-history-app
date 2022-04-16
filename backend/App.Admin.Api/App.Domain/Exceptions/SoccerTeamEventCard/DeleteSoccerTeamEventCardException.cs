using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
