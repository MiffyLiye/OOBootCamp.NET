using System.Collections.Generic;
using MoreLinq;

namespace OOBootCamp
{
    public class SmartParkingBoy : ParkingAgent<ParkingLot>
    {
        public SmartParkingBoy(params ParkingLot[] parkables) : base(parkables)
        {
        }

        protected override ParkingLot SelectParkable(ICollection<ParkingLot> parkingLots)
        {
            return parkingLots.MaxBy(p => p.EmptySpacesCount);
        }

        protected override string RoleInReport { get; } = "B";
    }
}
