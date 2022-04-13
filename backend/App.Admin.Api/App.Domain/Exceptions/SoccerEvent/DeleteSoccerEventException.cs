using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class DeleteSoccerEventException : Exception
    {
        public DeleteSoccerEventException(string message)
            : base(message)
        {
        }

        public DeleteSoccerEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected DeleteSoccerEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
