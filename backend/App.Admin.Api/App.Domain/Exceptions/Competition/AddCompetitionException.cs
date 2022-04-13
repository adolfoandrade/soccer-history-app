using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Competition
{
    [Serializable]
    public class AddCompetitionException : Exception
    {
        public AddCompetitionException(string message)
            : base(message)
        {
        }

        public AddCompetitionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddCompetitionException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
