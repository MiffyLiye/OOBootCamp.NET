using System.Linq;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public class ParkingBoy : ParkingPerson
    {

        public ParkingBoy(params ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override string Park(Car car)
        {
            var parkingLot = ParkingLots.FirstOrDefault(p => p.CanPark());
            if (parkingLot == null)
            {
                throw new ParkingFailedException("Cannot park at this moment.");
            }
            return parkingLot.Park(car);
        }
    }
}
