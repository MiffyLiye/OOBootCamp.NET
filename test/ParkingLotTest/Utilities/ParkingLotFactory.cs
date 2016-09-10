using System;
using OOBootCamp;

namespace ParkingLotTest.Utilities
{
    public class ParkingLotBuilder
    {
        private int OccupiedCount { get; set; }
        private int Capacity { get; set; }

        public ParkingLotBuilder()
        {
            Capacity = 0;
            OccupiedCount = 0;
        }

        public ParkingLotBuilder WithCapacity(int capacity)
        {
            Capacity = capacity;
            return this;
        }

        public ParkingLotBuilder WithOccupiedParkingSpace(int occupiedCount)
        {
            OccupiedCount = occupiedCount;
            return this;
        }

        public ParkingLot Create()
        {
            if (Capacity == 0 || Capacity < OccupiedCount)
            {
                throw new NotSupportedException("Capacity must be larger than zero, and occupide parking spaces must be smaller than capacity");
            }
            var parkingLot = new ParkingLot(Capacity);
            for (var i = 0; i < OccupiedCount; i++)
            {
                parkingLot.Park(new Car());
            }
            return parkingLot;
        }
    }
}
