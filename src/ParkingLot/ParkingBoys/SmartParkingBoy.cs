using System.Collections.Generic;
using MoreLinq;

namespace OOBootCamp
{
    public class SmartParkingBoy : ParkingAgent
    {
        public SmartParkingBoy(params ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        protected override ParkingLot SelectParkingLot(ICollection<ParkingLot> parkingLots)
        {
            return parkingLots.MaxBy(p => p.EmptySpacesCount);
        }
    }
}
