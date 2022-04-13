using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Competition
{
    [Serializable]
    public class UpdateCompetitionException : Exception
    {
        public UpdateCompetitionException(string message)
            : base(message)
        {
        }

        public UpdateCompetitionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected UpdateCompetitionException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
