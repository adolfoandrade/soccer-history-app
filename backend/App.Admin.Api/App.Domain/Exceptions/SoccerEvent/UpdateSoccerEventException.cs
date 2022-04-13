using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class UpdateSoccerEventException : Exception
    {
        public UpdateSoccerEventException(string message)
            : base(message)
        {
        }

        public UpdateSoccerEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected UpdateSoccerEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
