using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Competition
{
    [Serializable]
    public class DeleteCompetitionException : Exception
    {
        public DeleteCompetitionException(string message)
            : base(message)
        {
        }

        public DeleteCompetitionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected DeleteCompetitionException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
