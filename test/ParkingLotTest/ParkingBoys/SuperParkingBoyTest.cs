using System;
using FluentAssertions;
using OOBootCamp;
using OOBootCamp.Exceptions;
using ParkingLotTest.Utilities;
using Xunit;

namespace OOBootCampTest
{
    public class SuperParkingBoyTest
    {
        [Theory]
        [InlineData(1, 0, 2, 1, 0)]
        [InlineData(2, 1, 1, 0, 1)]
        public void should_park_to_parking_lot_with_higher_vacancy_rate(
            int parkingLot0Capacity,
            int parkingLot0OccupiedParkingSpace,
            int parkingLot1Capacity,
            int parkingLot1OccupiedParkingSpace,
            int chosenParkingLotIndex)
        {
            var parkingLot0 = new ParkingLotBuilder()
                .WithCapacity(parkingLot0Capacity)
                .WithOccupiedParkingSpace(parkingLot0OccupiedParkingSpace)
                .Create();
            var parkingLot1 = new ParkingLotBuilder()
                .WithCapacity(parkingLot1Capacity)
                .WithOccupiedParkingSpace(parkingLot1OccupiedParkingSpace)
                .Create();
            var parkingLots = new[] { parkingLot0, parkingLot1 };
            var superParkingBoy = new SuperParkingBoy(parkingLots);
            var car = new Car();

            var token = superParkingBoy.Park(car);

            var pickedCar = parkingLots[chosenParkingLotIndex].Pick(token);
            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_pick_the_same_car_after_parked_it()
        {
            var parkingLot = new ParkingLot(1);
            var superParkingBoy = new SuperParkingBoy(parkingLot);
            var car = new Car();
            var token = superParkingBoy.Park(car);

            var pickedCar = superParkingBoy.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_not_park_car_when_all_managed_parking_lots_are_full()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(1)
                .WithOccupiedParkingSpace(1)
                .Create();
            var superParkingBoy = new SuperParkingBoy(parkingLot);

            superParkingBoy.Invoking(p => p.Park(new Car()))
                .ShouldThrow<ParkingFailedException>()
                .WithMessage("Cannot park at this moment.");
        }

        [Fact]
        public void should_not_pick_car_when_the_car_is_not_in_parking_lot()
        {
            var superParkingBoy = new SuperParkingBoy(new ParkingLot(1));
            var token = Guid.NewGuid().ToString();

            superParkingBoy.Invoking(p => p.Pick(token))
                .ShouldThrow<CarNotFoundException>()
                .WithMessage("Cannot find the car.");
        }
    }
}
