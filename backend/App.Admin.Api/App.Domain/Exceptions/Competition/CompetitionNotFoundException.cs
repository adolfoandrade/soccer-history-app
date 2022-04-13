using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Competition
{
    [Serializable]
    public class CompetitionNotFoundException : Exception
    {
        public CompetitionNotFoundException(string message)
            : base(message)
        {
        }

        public CompetitionNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected CompetitionNotFoundException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
