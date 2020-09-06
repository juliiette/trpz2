using System;
using System.Runtime.Serialization;

namespace BLL.Implementation.Exceptions
{
    public class BuilderAtWorkException : ApplicationException
    {
        public BuilderAtWorkException() { }

        public BuilderAtWorkException(string message) : base(message) { }

        public BuilderAtWorkException(string message, Exception inner) : base(message, inner) { }

        protected BuilderAtWorkException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }

    }
}