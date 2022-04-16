using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Statistic
{
    [Serializable]
    public class DeleteStatisticException : Exception
    {
        public DeleteStatisticException(string message)
            : base(message)
        {
        }

        public DeleteStatisticException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected DeleteStatisticException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
