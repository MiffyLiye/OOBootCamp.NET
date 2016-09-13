using System;
using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public class ParkingBoy
    {
        private readonly ICollection<ParkingLot> _parkingLots;

        public ParkingBoy(params ParkingLot[] parkingLots)
        {
            _parkingLots = parkingLots;
        }

        public string Park(Car car)
        {
            var parkingLot = _parkingLots.FirstOrDefault(p => p.CanPark());
            if (parkingLot == null)
            {
                throw new NoSpaceException("Cannot park at this moment.");
            }
            return parkingLot.Park(car);
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
                throw new NotFoundException("Cannot find the car.");
            }
            return parkingLot.Pick(token);
        }
    }
}
