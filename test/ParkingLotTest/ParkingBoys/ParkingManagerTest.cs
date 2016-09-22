using System;
using OOBootCamp;
using OOBootCamp.Exceptions;
using ParkingLotTest.Utilities;
using Xunit;
using FluentAssertions;

namespace OOBootCampTest
{
    public class ParkingManagerTest
    {
        [Fact]
        public void should_park_car_when_manages_parking_lot()
        {
            var parkingLot = new ParkingLot(1);
            var parkingManager = new ParkingManager(parkingLot);
            var car = new Car();

            var token = parkingManager.Park(car);
            var pickedCar = parkingManager.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_park_car_when_manages_parking_boy()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);
            var car = new Car();

            var token = parkingManager.Park(car);
            var pickedCar = parkingManager.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_park_car_when_manages_smart_parking_boy()
        {
            var parkingLot = new ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(smartParkingBoy);
            var car = new Car();

            var token = parkingManager.Park(car);
            var pickedCar = parkingManager.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_park_car_when_manages_super_parking_boy()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new SuperParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);
            var car = new Car();

            var token = parkingManager.Park(car);
            var pickedCar = parkingManager.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_park_car_when_manages_multiple_parking_lots()
        {
            var fullParkingLot = new ParkingLotBuilder()
                .WithCapacity(1)
                .WithOccupiedParkingSpace(1)
                .Create();
            var parkingManager = new ParkingManager(fullParkingLot, new ParkingLot(1));
            var car = new Car();

            var token = parkingManager.Park(car);
            var pickedCar = parkingManager.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_not_park_car_when_all_managed_parking_lots_are_full()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(1)
                .WithOccupiedParkingSpace(1)
                .Create();
            var parkingManager = new ParkingManager(parkingLot);

            parkingManager.Invoking(p => p.Park(new Car()))
                .ShouldThrow<ParkingFailedException>()
                .WithMessage("Cannot park at this moment.");
        }

        [Fact]
        public void should_not_pick_car_when_the_car_is_not_in_parking_lot()
        {
            var parkingManager = new ParkingManager(new ParkingLot(1));
            var token = Guid.NewGuid().ToString();

            parkingManager.Invoking(p => p.Pick(token))
                .ShouldThrow<CarNotFoundException>()
                .WithMessage("Cannot find the car.");
        }

        [Fact]
        public void should_park_car_when_manages_multiple_parking_boys()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var smartParkingBoy = new SmartParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy, smartParkingBoy);
            var car = new Car();

            var token = parkingManager.Park(car);
            var pickedCar = parkingManager.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_park_car_when_manages_parking_lot_and_parking_boy()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingLot, parkingBoy);
            var car = new Car();

            var token = parkingManager.Park(car);
            var pickedCar = parkingManager.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }
    }
}
