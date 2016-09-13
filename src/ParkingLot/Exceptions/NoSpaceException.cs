using System;

namespace OOBootCamp.Exceptions
{
    public class NoSpaceException : InvalidOperationException
    {
        public NoSpaceException()
        {
        }

        public NoSpaceException(string message) : base(message)
        {
        }

        public NoSpaceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
