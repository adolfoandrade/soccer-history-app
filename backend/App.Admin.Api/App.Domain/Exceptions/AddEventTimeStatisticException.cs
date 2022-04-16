using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions
{
    [Serializable]
    public class AddEventTimeStatisticException : Exception
    {
        public AddEventTimeStatisticException(string message)
            : base(message)
        {
        }

        public AddEventTimeStatisticException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddEventTimeStatisticException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
