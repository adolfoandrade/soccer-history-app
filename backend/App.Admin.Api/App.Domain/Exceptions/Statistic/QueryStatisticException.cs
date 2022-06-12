using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Exceptions.Statistic
{
    [Serializable]
    public class QueryStatisticException : Exception
    {
        public QueryStatisticException(string message)
            : base(message)
        {
        }

        public QueryStatisticException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryStatisticException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
