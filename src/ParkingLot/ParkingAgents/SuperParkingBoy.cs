using System.Collections.Generic;
using MoreLinq;

namespace OOBootCamp
{
    public class SuperParkingBoy : ParkingAgent<ParkingLot>
    {
        public SuperParkingBoy(params ParkingLot[] parkables) : base(parkables)
        {
        }

        protected override ParkingLot SelectParkable(ICollection<ParkingLot> parkingLots)
        {
            return parkingLots.MaxBy(p => (decimal) p.EmptySpacesCount / p.Capacity);
        }

        public override void Accept(IParkableVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
