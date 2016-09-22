namespace OOBootCamp
{
    public interface IParkable : IParkingReportable
    {
        bool CanPark();
        string Park(Car car);
        bool CanPick(string token);
        Car Pick(string token);
    }
}
