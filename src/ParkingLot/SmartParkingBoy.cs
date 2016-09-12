using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace OOBootCamp
{
    public class SmartParkingBoy
    {
        private readonly ICollection<ParkingLot> _parkingLots;

        public SmartParkingBoy(params ParkingLot[] parkingLots)
        {
            _parkingLots = parkingLots;
        }

        public string Park(Car car)
        {
            return _parkingLots.MaxBy(p => p.EmptySpacesCount).Park(car);
        }

        public bool CanPark()
        {
            return _parkingLots.Any(p => p.CanPark());
        }

        public Car Pick(string token)
        {
            var parkingLot = _parkingLots.FirstOrDefault(p => p.CanPick(token));
            if (parkingLot == null)
            {
                throw new InvalidOperationException("Cannot find the car.");
            }
            return parkingLot.Pick(token);
        }
    }
}
