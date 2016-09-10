using System.Linq;

namespace OOBootCamp
{
    public class ParkingBoy
    {
        private readonly ParkingLot[] _parkingLots;
        public ParkingBoy(params ParkingLot[] parkingLots)
        {
            _parkingLots = parkingLots;
        }

        public string Park(Car car)
        {
            return _parkingLots.First(p => p.CanPark()).Park(car);
        }

        public Car Pick(string token)
        {
            return _parkingLots.First(p => p.CanPick(token)).Pick(token);
        }
    }
}
