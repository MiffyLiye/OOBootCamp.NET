using System;

namespace OOBootCamp.Exceptions
{
    public class CarNotFoundException : InvalidOperationException
    {
        public CarNotFoundException()
        {
        }

        public CarNotFoundException(string message) : base(message)
        {
        }

        public CarNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
