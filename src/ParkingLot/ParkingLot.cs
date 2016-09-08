using System;
using System.Collections.Generic;

namespace OOBootCamp
{
    public class Car
    {
    }

    public class ParkingLot
    {
        private readonly Dictionary<string, Car> _lot = new Dictionary<string, Car>();
        private readonly int _capacity;

        public ParkingLot(int capacity)
        {
            this._capacity = capacity;
        }

        public string Park(Car car)
        {
            if (_lot.Count >= _capacity)
            {
                throw new InvalidOperationException("No space.");
            }
            var token = Guid.NewGuid().ToString();
            _lot.Add(token, car);
            return token;
        }

        public Car Pick(string token)
        {
            if (!_lot.ContainsKey(token))
            {
                throw new InvalidOperationException("Not found.");
            }
            var car = _lot[token];
            _lot.Remove(token);
            return car;
        }

        public bool CanPark()
        {
            return _lot.Count < _capacity;
        }
    }
}
