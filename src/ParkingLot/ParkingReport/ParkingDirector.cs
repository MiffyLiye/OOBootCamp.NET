namespace OOBootCamp
{
    public class ParkingDirector
    {
        private readonly ParkingManager _parkingManager;
        private readonly ParkingReportVisitor _parkingReportVisitor = new ParkingReportVisitor();

        public ParkingDirector(ParkingManager parkingManager)
        {
            this._parkingManager = parkingManager;
        }

        public ParkingReport ParkingReport => (ParkingReport) _parkingManager.Accept(_parkingReportVisitor);
    }
}