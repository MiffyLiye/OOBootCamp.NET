using System;
using FluentAssertions;
using OOBootCamp;
using ParkingLotTest.Utilities;
using Xunit;

namespace OOBootCampTest
{
    public class ParkingReportTests
    {
        public static string NewLine => Environment.NewLine;

        [Fact]
        public void should_report_when_manager_manages_nothing()
        {
            var parkingManager = new ParkingManager();

            parkingManager.ParkingReport.ToString().Should().Be("M 0 0");
        }

        [Fact]
        public void should_report_when_manager_manages_one_parking_lot()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(2)
                .WithOccupiedParkingSpace(1)
                .Create();
            var parkingManager = new ParkingManager(parkingLot);

            parkingManager.ParkingReport.ToString().Should().Be(
                "M 1 2" + NewLine +
                "  P 1 2");
        }

        [Fact]
        public void should_report_when_manager_manages_one_parking_boy()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(2)
                .WithOccupiedParkingSpace(1)
                .Create();
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);

            parkingManager.ParkingReport.ToString().Should().Be(
                "M 1 2" + NewLine +
                "  B 1 2" + NewLine +
                "    P 1 2");
        }

        [Fact]
        public void should_report_when_manager_manages_one_smart_parking_boy()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(2)
                .WithOccupiedParkingSpace(1)
                .Create();
            var parkingBoy = new SmartParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);

            parkingManager.ParkingReport.ToString().Should().Be(
                "M 1 2" + NewLine +
                "  B 1 2" + NewLine +
                "    P 1 2");
        }

        [Fact]
        public void should_report_when_manager_manages_one_super_parking_boy()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(2)
                .WithOccupiedParkingSpace(1)
                .Create();
            var parkingBoy = new SuperParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);

            parkingManager.ParkingReport.ToString().Should().Be(
                "M 1 2" + NewLine +
                "  B 1 2" + NewLine +
                "    P 1 2");
        }

        [Fact]
        public void should_report_when_manager_manages_one_parking_lot_and_different_parking_boys()
        {
            var parkingLot = new ParkingLotBuilder()
                .WithCapacity(100)
                .WithOccupiedParkingSpace(10)
                .Create();
            var parkingBoy =
                new ParkingBoy(new ParkingLotBuilder().WithCapacity(200).WithOccupiedParkingSpace(20).Create());
            var smartParkingBoy =
                new SmartParkingBoy(new ParkingLotBuilder().WithCapacity(300).WithOccupiedParkingSpace(30).Create());
            var superParkingBoy = new SuperParkingBoy(
                new ParkingLotBuilder().WithCapacity(400).WithOccupiedParkingSpace(40).Create());
            var parkingManager = new ParkingManager(parkingLot, parkingBoy, smartParkingBoy, superParkingBoy);

            var actualReportText = parkingManager.ParkingReport.ToString();

            actualReportText.Should().StartWith("M 100 1000");
            actualReportText.Should().Contain("  P 10 100");
            actualReportText.Should().Contain("  B 20 200" + NewLine +
                                              "    P 20 200");
            actualReportText.Should().Contain("  B 30 300" + NewLine +
                                              "    P 30 300");
            actualReportText.Should().Contain("  B 40 400" + NewLine +
                                              "    P 40 400");
        }
    }
}
