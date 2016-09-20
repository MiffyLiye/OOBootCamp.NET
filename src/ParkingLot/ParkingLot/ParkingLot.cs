using System;
using System.Collections.Generic;
using OOBootCamp.Exceptions;

namespace OOBootCamp
{
    public class ParkingLot : IParkable
    {
        private Dictionary<string, Car> OccupiedLots { get; }
        private int Capacity { get; }

        public ParkingLot(int capacity)
        {
            OccupiedLots = new Dictionary<string, Car>();
            Capacity = capacity;
        }

        public decimal VacancyRate => (decimal) EmptySpacesCount / Capacity;

        public bool CanPark()
        {
            return HasEmptySpace();
        }

        public string Park(Car car)
        {
            if (!HasEmptySpace())
            {
                throw new ParkingFailedException("No space.");
            }
            var token = Guid.NewGuid().ToString();
            OccupiedLots.Add(token, car);
            return token;
        }

        public bool CanPick(string token)
        {
            return IsCarInLot(token);
        }

        public Car Pick(string token)
        {
            if (!IsCarInLot(token))
            {
                throw new CarNotFoundException("Not found.");
            }
            var car = OccupiedLots[token];
            OccupiedLots.Remove(token);
            return car;
        }

        public int EmptySpacesCount => Capacity - OccupiedLots.Count;

        private bool HasEmptySpace()
        {
            return OccupiedLots.Count < Capacity;
        }

        private bool IsCarInLot(string token)
        {
            return OccupiedLots.ContainsKey(token);
        }
    }
}
