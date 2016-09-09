using System;
using FluentAssertions;
using OOBootCamp;
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
            var parkingLot = new ParkingLot(1);
            parkingLot.Park(new Car());

            parkingLot.CanPark().Should().BeFalse();
        }
    }
}
