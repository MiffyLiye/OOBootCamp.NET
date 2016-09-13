using System.Collections.Generic;
using MoreLinq;
using OOBootCamp.Abilities;

namespace OOBootCamp
{
    public class SmartParkingBoy
    {
        private ICollection<ParkingLot> ParkingLots { get; }
        private ParkingLotAgentAbility ParkingLotAgentAbility { get; }

        public SmartParkingBoy(params ParkingLot[] parkingLots)
        {
            ParkingLots = parkingLots;
            ParkingLotAgentAbility = new ParkingLotAgentAbility(ParkingLots, ps => ps.MaxBy(p => p.EmptySpacesCount));
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
