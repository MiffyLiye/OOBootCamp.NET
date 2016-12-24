namespace OOBootCamp
{
    public class ParkingDirector
    {
        private readonly ParkingManager _parkingManager;
        private ParkingReportVisitor _parkingReportVisitor = new ParkingReportVisitor();
        public ParkingDirector(ParkingManager parkingManager)
        {
            this._parkingManager = parkingManager;
        }

        public ParkingReport ParkingReport
        {
            get
            {
                _parkingManager.Accept(_parkingReportVisitor);
                return _parkingReportVisitor.ParkingReport;
            }
        }
    }
}
