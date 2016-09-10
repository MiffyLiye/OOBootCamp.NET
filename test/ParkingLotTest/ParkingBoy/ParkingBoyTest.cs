using FluentAssertions;
using OOBootCamp;
using ParkingLotTest.Utilities;
using Xunit;

namespace OOBootCampTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void should_park_successfully_when_manages_one_parking_lot()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();

            var token = parkingBoy.Park(car);

            var pickedCar = parkingLot.Pick(token);
            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_pick_the_same_car_after_parked_car()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingBoy.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_park_successfully_when_one_parking_lot_is_full_but_another_is_not_full()
        {
            var oneParkingLot = new ParkingLotBuilder()
                .WithCapacity(1)
                .WithOccupiedParkingSpace(1)
                .Create();
            var anotherParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(oneParkingLot, anotherParkingLot);
            var car = new Car();

            var token = parkingBoy.Park(car);

            var pickedCar = anotherParkingLot.Pick(token);
            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_pick_the_right_car_successfully_when_manages_two_parking_lot()
        {
            var oneParkingLot = new ParkingLotBuilder()
                .WithCapacity(1)
                .WithOccupiedParkingSpace(1)
                .Create();
            var anotherParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(oneParkingLot, anotherParkingLot);
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingBoy.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }
    }
}
