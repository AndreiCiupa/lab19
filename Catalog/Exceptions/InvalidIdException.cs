using System.Runtime.Serialization;

namespace Catalog.Exceptions
{
    [Serializable]
    internal class InvalidIdException : Exception
    {
        public InvalidIdException()
        {
        }

        public InvalidIdException(string? message) : base(message)
        {
        }

        public InvalidIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}