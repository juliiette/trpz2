using System;
using System.Runtime.Serialization;

namespace BLL.Implementation.Exceptions
{
    public class LimitedBricksPerSessionException : Exception
    {
        public LimitedBricksPerSessionException() { }

        public LimitedBricksPerSessionException(string message) : base(message) { }

        public LimitedBricksPerSessionException(string message, Exception inner) : base(message, inner) { }

        protected LimitedBricksPerSessionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}