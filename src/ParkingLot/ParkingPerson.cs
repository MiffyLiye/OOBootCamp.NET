using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public abstract class ParkingPerson
    {
        protected readonly ICollection<ParkingLot> ParkingLots;

        protected ParkingPerson(params ParkingLot[] parkingLots)
        {
            ParkingLots = parkingLots;
        }

        public bool CanPark()
        {
            return ParkingLots.Any(p => p.CanPark());
        }

        public abstract string Park(Car car);

        public bool CanPick(string token)
        {
            return ParkingLots.Any(p => p.CanPick(token));
        }

        public Car Pick(string token)
        {
            var parkingLot = ParkingLots.FirstOrDefault(p => p.CanPick(token));
            if (parkingLot == null)
            {
                throw new NotFoundException("Cannot find the car.");
            }
            return parkingLot.Pick(token);
        }
    }
}
