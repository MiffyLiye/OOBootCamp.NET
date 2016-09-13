using System;

namespace OOBootCamp.Exceptions
{
    public class ParkingFailedException : InvalidOperationException
    {
        public ParkingFailedException()
        {
        }

        public ParkingFailedException(string message) : base(message)
        {
        }

        public ParkingFailedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
