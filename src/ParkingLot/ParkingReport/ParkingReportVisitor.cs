using System.Linq;

namespace OOBootCamp
{
    public class ParkingReportVisitor : IParkableVisitor
    {
        public object Visit(ParkingLot parkingLot)
        {
            return new ParkingReport(ParkingReportRoles.ParkingLot,
                parkingLot.Capacity - parkingLot.EmptySpacesCount, parkingLot.Capacity);
        }

        public object Visit(ParkingBoy parkingBoy)
        {
            return Visit(parkingBoy, ParkingReportRoles.ParkingBoy);
        }

        public object Visit(SmartParkingBoy smartParkingBoy)
        {
            return Visit(smartParkingBoy, ParkingReportRoles.SmartParkingBoy);
        }

        public object Visit(SuperParkingBoy superParkingBoy)
        {
            return Visit(superParkingBoy, ParkingReportRoles.SuperParkingBoy);
        }

        public object Visit(ParkingManager parkingManager)
        {
            return Visit(parkingManager, ParkingReportRoles.ParkingManager);
        }

        private object Visit<TManaged>(ParkingAgent<TManaged> parkingAgent, string role) where TManaged : IParkable
        {
            return new ParkingReport(role, parkingAgent.Parkables.Select(parkable => (ParkingReport) parkable.Accept(this)).ToList());
        }
    }
}
