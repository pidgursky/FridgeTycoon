using System;
using System.Runtime.Serialization;

namespace FT.Queries.Exceptions
{
    //TODO: move class to a shared library
    [Serializable]
    internal class NotFoundException : Exception
    {
        private readonly string v;
        private readonly Guid id;

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string v, Guid id)
        {
            this.v = v;
            this.id = id;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
