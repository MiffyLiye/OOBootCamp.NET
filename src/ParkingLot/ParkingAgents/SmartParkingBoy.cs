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

        public override T Accept<T>(IParkableVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
