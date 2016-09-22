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
            return parkingLots.MaxBy(p => p.VacancyRate);
        }

        protected override string RoleInReport { get; } = "B";
    }
}
