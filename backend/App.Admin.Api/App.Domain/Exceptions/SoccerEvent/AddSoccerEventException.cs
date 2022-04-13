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
    public class AddSoccerEventException : Exception
    {
        public AddSoccerEventException(string message)
            : base(message)
        {
        }

        public AddSoccerEventException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddSoccerEventException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
