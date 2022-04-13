using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Exceptions.SoccerEvent
{
    [Serializable]
    public class QueryBySeasonSoccerEventException : Exception
    {
        public QueryBySeasonSoccerEventException(string message)
            : base(message)
        {
        }

        public QueryBySeasonSoccerEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected QueryBySeasonSoccerEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
