using System.Collections.Generic;

namespace OOBootCamp
{
    public class ParkingReportVisitor : IParkableVisitor
    {
        public ParkingReport ParkingReport;

        public void Visit(ParkingLot parkingLot)
        {
            ParkingReport = new ParkingReport(ParkingReportRoles.ParkingLot,
                parkingLot.Capacity - parkingLot.EmptySpacesCount, parkingLot.Capacity);
        }

        public void Visit(ParkingBoy parkingBoy)
        {
            Visit(parkingBoy, ParkingReportRoles.ParkingBoy);
        }

        public void Visit(SmartParkingBoy smartParkingBoy)
        {
            Visit(smartParkingBoy, ParkingReportRoles.SmartParkingBoy);
        }

        public void Visit(SuperParkingBoy superParkingBoy)
        {
            Visit(superParkingBoy, ParkingReportRoles.SuperParkingBoy);
        }

        public void Visit(ParkingManager parkingManager)
        {
            Visit(parkingManager, ParkingReportRoles.ParkingManager);
        }

        private void Visit<TManaged>(ParkingAgent<TManaged> parkingAgent, string role) where TManaged : IParkable
        {
            var subReports = new List<ParkingReport>();
            foreach (var parkable in parkingAgent.Parkables)
            {
                parkable.Accept(this);
                subReports.Add(ParkingReport);
            }
            ParkingReport = new ParkingReport(role, subReports);
        }
    }
}
