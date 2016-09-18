using System.Collections.Generic;
using MoreLinq;

namespace OOBootCamp
{
    public class SuperParkingBoy : ParkingAgent
    {
        public SuperParkingBoy(params ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        protected override ParkingLot SelectParkingLot(ICollection<ParkingLot> parkingLots)
        {
            return parkingLots.MaxBy(p => (decimal)p.EmptySpacesCount / p.Capacity);
        }
    }
}
