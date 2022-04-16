using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Statistic
{
    [Serializable]
    public class UpdateStatisticException : Exception
    {
        public UpdateStatisticException(string message)
            : base(message)
        {
        }

        public UpdateStatisticException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected UpdateStatisticException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
