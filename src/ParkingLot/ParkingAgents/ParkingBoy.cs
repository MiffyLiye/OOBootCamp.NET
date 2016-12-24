using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp
{
    public class ParkingBoy : ParkingAgent<ParkingLot>
    {
        public ParkingBoy(params ParkingLot[] parkables) : base(parkables)
        {
        }

        protected override ParkingLot SelectParkable(ICollection<ParkingLot> parkingLots)
        {
            return parkingLots.First(p => p.CanPark());
        }

        public override object Accept(IParkableVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
