using System;
using FluentAssertions;
using OOBootCamp;
using ParkingLotTest.Utilities;
using Xunit;

namespace OOBootCampTest.UT
{
    public class ParkingLotStatusTests
    {
        [Fact]
        public void should_get_can_park_info_when_parking_lot_is_not_full()
        {
            var parkingLot = new ParkingLot(1);

            parkingLot.CanPark().Should().BeTrue();
        }

        [Fact]
        public void should_get_cannot_park_info_when_parking_lot_is_full()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(1)
                .WithOccupiedParkingSpace(1)
                .Create();

            parkingLot.CanPark().Should().BeFalse();
        }

        [Fact]
        public void should_get_can_pick_info_when_car_is_in_parking_lot()
        {
            var parkingLot = new ParkingLot(1);
            var token = parkingLot.Park(new Car());

            parkingLot.CanPick(token).Should().BeTrue();
        }

        [Fact]
        public void should_get_cannot_pick_info_when_car_is_not_in_parking_lot()
        {
            var parkingLot = new ParkingLot(1);
            var token = Guid.NewGuid().ToString();

            parkingLot.CanPick(token).Should().BeFalse();
        }
    }
}
