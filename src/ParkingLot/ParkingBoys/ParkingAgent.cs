using System.Linq;
using System.Collections.Generic;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public abstract class ParkingAgent
    {
        private ICollection<ParkingLot> ParkingLots { get; }

        protected ParkingAgent(ICollection<ParkingLot> parkingLots)
        {
            ParkingLots = parkingLots;
        }

        protected abstract ParkingLot SelectParkingLot(ICollection<ParkingLot> parkingLots);

        public bool CanPark()
        {
            return ParkingLots.Any(p => p.CanPark());
        }

        public string Park(Car car)
        {
            if (!CanPark())
            {
                throw new ParkingFailedException("Cannot park at this moment.");
            }
            return SelectParkingLot(ParkingLots).Park(car);
        }

        public bool CanPick(string token)
        {
            return ParkingLots.Any(p => p.CanPick(token));
        }

        public Car Pick(string token)
        {
            var parkingLot = ParkingLots.FirstOrDefault(p => p.CanPick(token));
            if (parkingLot == null)
            {
                throw new CarNotFoundException("Cannot find the car.");
            }
            return parkingLot.Pick(token);
        }
    }
}
