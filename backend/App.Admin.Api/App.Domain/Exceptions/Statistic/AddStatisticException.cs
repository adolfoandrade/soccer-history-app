using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace App.Domain.Exceptions.Statistic
{
    [Serializable]
    public class AddStatisticException : Exception
    {
        public AddStatisticException(string message)
            : base(message)
        {
        }

        public AddStatisticException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddStatisticException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
