using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class AddMatchException : Exception
    {
        public AddMatchException(string message)
            : base(message)
        {
        }

        public AddMatchException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddMatchException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
