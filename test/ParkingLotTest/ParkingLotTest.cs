using System;
using FluentAssertions;
using OOBootCamp;
using Xunit;

namespace OOBootCampTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_pick_the_same_car_after_parked_car()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();

            var token = parkingLot.Park(car);
            var pickedCar = parkingLot.Pick(token);

            pickedCar.Should().BeSameAs(car);
        }

        [Fact]
        public void should_pick_the_corresponding_car_after_parked_two_cars()
        {
            var parkingLot = new ParkingLot(2);
            var myCar = new Car();
            var myToken = parkingLot.Park(myCar);
            var otherCar = new Car();
            var otherToken = parkingLot.Park(otherCar);

            var pickedMyCar = parkingLot.Pick(myToken);
            var pickedOtherCar = parkingLot.Pick(otherToken);

            pickedMyCar.Should().BeSameAs(myCar);
            pickedOtherCar.Should().BeSameAs(otherCar);
        }

        [Fact]
        public void should_park_unsucccessfully_when_parking_lot_is_full()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.Park(new Car());

            parkingLot.Invoking(p => p.Park(new Car()))
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("No space.");
        }

        [Fact]
        public void should_pick_car_unsuccessfully_when_car_already_picked()
        {
            var parkingLot = new ParkingLot(2);
            var car = new Car();
            var token = parkingLot.Park(car);
            parkingLot.Pick(token);

            parkingLot.Invoking(p => p.Pick(token))
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Not found.");
        }

        [Fact]
        public void should_pick_car_unsuccessfully_when_never_parked_the_car()
        {
            var parkingLot = new ParkingLot(1);
            var invalidToken = Guid.NewGuid().ToString();

            parkingLot.Invoking(p => p.Pick(invalidToken))
                .ShouldThrow<InvalidOperationException>()
                .WithMessage("Not found.");
        }

        [Fact]
        public void should_get_can_park_info_when_parking_lot_is_not_full()
        {
            var parkingLot = new ParkingLot(1);

            parkingLot.CanPark().Should().BeTrue();
        }

        [Fact]
        public void should_get_cannot_park_info_when_parking_lot_is_full()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.Park(new Car());

            parkingLot.CanPark().Should().BeFalse();
        }
    }
}
