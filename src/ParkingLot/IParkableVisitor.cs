namespace OOBootCamp
{
    public interface IParkableVisitor
    {
        object Visit(ParkingLot parkingLot);
        object Visit(ParkingBoy parkingBoy);
        object Visit(SmartParkingBoy smartParkingBoy);
        object Visit(SuperParkingBoy superParkingBoy);
        object Visit(ParkingManager parkingManager);
    }
}
