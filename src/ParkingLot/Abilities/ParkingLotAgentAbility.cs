using System;
using System.Collections.Generic;
using System.Linq;
using OOBootCamp.Exceptions;

namespace OOBootCamp.Abilities
{
    internal class ParkingLotAgentAbility
    {
        private ICollection<ParkingLot> ParkingLots { get; }
        private Func<ICollection<ParkingLot>, ParkingLot> SelectParkingLot { get; }

        public ParkingLotAgentAbility(ICollection<ParkingLot> parkingLots,
            Func<ICollection<ParkingLot>, ParkingLot> selectParkingLot)
        {
            ParkingLots = parkingLots;
            SelectParkingLot = selectParkingLot;
        }

        public bool CanPark()
        {
            return ParkingLots.Any(p => p.CanPark());
        }

        public string Park(Car car)
        {
            if (!CanPark())
            {
                throw new ParkingFailedException("Cannot park at this moment.");
            }
            return SelectParkingLot(ParkingLots).Park(car);
        }

        public bool CanPick(string token)
        {
            return ParkingLots.Any(p => p.CanPick(token));
        }

        public Car Pick(string token)
        {
            var parkingLot = ParkingLots.FirstOrDefault(p => p.CanPick(token));
            if (parkingLot == null)
            {
                throw new CarNotFoundException("Cannot find the car.");
            }
            return parkingLot.Pick(token);
        }
    }
}
