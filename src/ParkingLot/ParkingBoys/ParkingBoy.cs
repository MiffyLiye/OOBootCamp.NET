using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Abilities;

namespace OOBootCamp
{
    public class ParkingBoy
    {
        private ICollection<ParkingLot> ParkingLots { get; }
        private ParkingLotAgentAbility ParkingLotAgentAbility { get; }

        public ParkingBoy(params ParkingLot[] parkingLots)
        {
            ParkingLots = parkingLots;
            ParkingLotAgentAbility = new ParkingLotAgentAbility(ParkingLots, ps => ps.First(p => p.CanPark()));
        }

        public bool CanPark()
        {
            return ParkingLotAgentAbility.CanPark();
        }

        public string Park(Car car)
        {
            return ParkingLotAgentAbility.Park(car);
        }

        public bool CanPick(string token)
        {
            return ParkingLotAgentAbility.CanPick(token);
        }

        public Car Pick(string token)
        {
            return ParkingLotAgentAbility.Pick(token);
        }
    }
}
