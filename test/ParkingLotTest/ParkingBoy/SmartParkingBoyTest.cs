using FluentAssertions;
using OOBootCamp;
using Xunit;

namespace OOBootCampTest
{
    public class SmartParkingBoyTest
    {
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, 0)]
        public void should_park_to_parking_lot_with_more_empty_space(
            int parkingLot0EmptySpaces,
            int parkingLot1EmptySpaces,
            int chosenParkingLotIndex)
        {
            var parkingLots = new[] {new ParkingLot(parkingLot0EmptySpaces), new ParkingLot(parkingLot1EmptySpaces)};
            var smartParkingBoy = new SmartParkingBoy(parkingLots);
            var car = new Car();

            var token = smartParkingBoy.Park(car);

            var pickedCar = parkingLots[chosenParkingLotIndex].Pick(token);
            pickedCar.Should().BeSameAs(car);
        }
    }
}
