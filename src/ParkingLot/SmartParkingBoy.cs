using MoreLinq;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public class SmartParkingBoy : ParkingPerson
    {
        public SmartParkingBoy(params ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override string Park(Car car)
        {
            if (!CanPark())
            {
                throw new NoSpaceException("Cannot park at this moment.");
            }
            return ParkingLots.MaxBy(p => p.EmptySpacesCount).Park(car);
        }
    }
}
