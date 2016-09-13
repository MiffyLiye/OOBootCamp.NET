using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp
{
    public class ParkingBoy : ParkingAgent
    {
        public ParkingBoy(params ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        protected override ParkingLot SelectParkingLot(ICollection<ParkingLot> parkingLots)
        {
            return parkingLots.First(p => p.CanPark());
        }
    }
}
