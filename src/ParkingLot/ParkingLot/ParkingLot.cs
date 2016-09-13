using System;
using System.Collections.Generic;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public class ParkingLot
    {
        private readonly Dictionary<string, Car> _lot = new Dictionary<string, Car>();
        private readonly int _capacity;

        public ParkingLot(int capacity)
        {
            _capacity = capacity;
        }

        public bool CanPark()
        {
            return HasEmptySpace();
        }

        public string Park(Car car)
        {
            if (!HasEmptySpace())
            {
                throw new ParkingFailedException("No space.");
            }
            var token = Guid.NewGuid().ToString();
            _lot.Add(token, car);
            return token;
        }

        public bool CanPick(string token)
        {
            return IsCarInLot(token);
        }

        public Car Pick(string token)
        {
            if (!IsCarInLot(token))
            {
                throw new CarNotFoundException("Not found.");
            }
            var car = _lot[token];
            _lot.Remove(token);
            return car;
        }

        public int EmptySpacesCount => _capacity - _lot.Count;

        private bool HasEmptySpace()
        {
            return _lot.Count < _capacity;
        }

        private bool IsCarInLot(string token)
        {
            return _lot.ContainsKey(token);
        }
    }
}
