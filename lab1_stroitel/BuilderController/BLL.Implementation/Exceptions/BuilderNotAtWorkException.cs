using System;
using System.Runtime.Serialization;

namespace BLL.Implementation.Exceptions
{
    public class BuilderNotAtWorkException : Exception
    {
        public BuilderNotAtWorkException() { }

        public BuilderNotAtWorkException(string message) : base(message) { }

        public BuilderNotAtWorkException(string message, Exception inner) : base(message, inner) { }

        protected BuilderNotAtWorkException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}