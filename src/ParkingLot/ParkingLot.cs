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

        public string Park(Car car)
        {
            var token = Guid.NewGuid().ToString();
            _lot.Add(token, car);
            return token;
        }

        public Car Pick(string token)
        {
            if (!_lot.ContainsKey(token))
            {
                throw new InvalidOperationException("Not Found");
            }
            var car = _lot[token];
            _lot.Remove(token);
            return car;
        }
    }
}
