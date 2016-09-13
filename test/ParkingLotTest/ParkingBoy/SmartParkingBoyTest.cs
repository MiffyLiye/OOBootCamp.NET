using System;
using FluentAssertions;
using OOBootCamp;
using OOBootCamp.Exceptions;
using ParkingLotTest.Utilities;
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

        [Fact]
        public void should_pick_the_same_car_after_parked_it()
        {
            var parkingLot = new ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(parkingLot);
            var car = new Car();
            var token = smartParkingBoy.Park(car);

            var pickedCar = smartParkingBoy.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_not_park_car_when_all_managed_parking_lots_are_full()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(1)
                .WithOccupiedParkingSpace(1)
                .Create();
            var smartParkingBoy = new SmartParkingBoy(parkingLot);

            smartParkingBoy.Invoking(p => p.Park(new Car()))
                .ShouldThrow<NoSpaceException>()
                .WithMessage("Cannot park at this moment.");
        }

        [Fact]
        public void should_not_pick_car_when_the_car_is_not_in_parking_lot()
        {
            var smartParkingBoy = new SmartParkingBoy(new ParkingLot(1));
            var token = Guid.NewGuid().ToString();

            smartParkingBoy.Invoking(p => p.Pick(token))
                .ShouldThrow<NotFoundException>()
                .WithMessage("Cannot find the car.");
        }
    }
}
