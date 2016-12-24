namespace OOBootCamp
{
    public interface IParkableVisitor
    {
        void Visit(ParkingLot parkingLot);
        void Visit(ParkingBoy parkingBoy);
        void Visit(SmartParkingBoy smartParkingBoy);
        void Visit(SuperParkingBoy superParkingBoy);
        void Visit(ParkingManager parkingManager);
    }
}
