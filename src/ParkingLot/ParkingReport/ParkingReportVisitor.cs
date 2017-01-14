using System.Linq;

namespace OOBootCamp
{
    public class ParkingReportVisitor : IParkableVisitor<ParkingReport>
    {
        public ParkingReport Visit(ParkingLot parkingLot)
        {
            return new ParkingReport(ParkingReportRoles.ParkingLot,
                parkingLot.Capacity - parkingLot.EmptySpacesCount, parkingLot.Capacity);
        }

        public ParkingReport Visit(ParkingBoy parkingBoy)
        {
            return Visit(parkingBoy, ParkingReportRoles.ParkingBoy);
        }

        public ParkingReport Visit(SmartParkingBoy smartParkingBoy)
        {
            return Visit(smartParkingBoy, ParkingReportRoles.SmartParkingBoy);
        }

        public ParkingReport Visit(SuperParkingBoy superParkingBoy)
        {
            return Visit(superParkingBoy, ParkingReportRoles.SuperParkingBoy);
        }

        public ParkingReport Visit(ParkingManager parkingManager)
        {
            return Visit(parkingManager, ParkingReportRoles.ParkingManager);
        }

        private ParkingReport Visit<TManaged>(ParkingAgent<TManaged> parkingAgent, string role) where TManaged : IParkable
        {
            return new ParkingReport(role, parkingAgent.Parkables.Select(parkable => (ParkingReport) parkable.Accept(this)).ToList());
        }
    }
}
