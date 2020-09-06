using System;
using System.Runtime.Serialization;

namespace BLL.Implementation.Exceptions
{
    public class MoreTimeForBreakException : Exception
    {
        public MoreTimeForBreakException() { }

        public MoreTimeForBreakException(string message) : base(message) { }

        public MoreTimeForBreakException(string message, Exception inner) : base(message, inner) { }

        protected MoreTimeForBreakException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}