using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp
{
    public class ParkingManager : ParkingAgent<IParkable>
    {
        public ParkingManager(params IParkable[] parkables) : base(parkables)
        {
        }

        protected override IParkable SelectParkable(ICollection<IParkable> parkables)
        {
            return parkables.First(p => p.CanPark());
        }
    }
}
