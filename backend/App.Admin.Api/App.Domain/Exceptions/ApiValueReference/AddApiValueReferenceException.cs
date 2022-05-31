using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Exceptions.ApiValueReference
{
    [Serializable]
    public class AddApiValueReferenceException : Exception
    {
        public AddApiValueReferenceException(string message)
            : base(message)
        {
        }

        public AddApiValueReferenceException(string message, Exception inner)
            : base(message, inner)
        {
        }

        [ExcludeFromCodeCoverage]
        protected AddApiValueReferenceException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
