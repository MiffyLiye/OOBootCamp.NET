using System.Linq;
using System.Collections.Generic;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public abstract class ParkingAgent<TManaged> : IParkable where TManaged : IParkable
    {
        public ICollection<TManaged> Parkables { get; }
        protected ParkingAgent(ICollection<TManaged> parkables)
        {
            Parkables = parkables;
        }

        protected abstract TManaged SelectParkable(ICollection<TManaged> parkingLots);

        public bool CanPark()
        {
            return Parkables.Any(p => p.CanPark());
        }

        public string Park(Car car)
        {
            if (!CanPark())
            {
                throw new ParkingFailedException("Cannot park at this moment.");
            }
            return SelectParkable(Parkables).Park(car);
        }

        public bool CanPick(string token)
        {
            return Parkables.Any(p => p.CanPick(token));
        }

        public Car Pick(string token)
        {
            var parkingLot = Parkables.FirstOrDefault(p => p.CanPick(token));
            if (parkingLot == null)
            {
                throw new CarNotFoundException("Cannot find the car.");
            }
            return parkingLot.Pick(token);
        }

        public abstract void Accept(IParkableVisitor visitor);
    }
}
