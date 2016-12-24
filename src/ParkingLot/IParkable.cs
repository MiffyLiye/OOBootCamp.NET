namespace OOBootCamp
{
    public interface IParkable
    {
        bool CanPark();
        string Park(Car car);
        bool CanPick(string token);
        Car Pick(string token);
        object Accept(IParkableVisitor visitor);
    }
}
