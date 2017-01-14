namespace OOBootCamp
{
    public interface IParkableVisitor<out T>
    {
        T Visit(ParkingLot parkingLot);
        T Visit(ParkingBoy parkingBoy);
        T Visit(SmartParkingBoy smartParkingBoy);
        T Visit(SuperParkingBoy superParkingBoy);
        T Visit(ParkingManager parkingManager);
    }
}
