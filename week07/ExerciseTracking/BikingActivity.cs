
public class BikingActivity: Activity
{
    private double _distance;
    
    public BikingActivity(DateTime startDate, DateTime endDate, double distance) :
        base(startDate, endDate)
    {
        _distance = distance;
    }

    protected override double GetDistance()
    {
        return _distance;
    }

    protected override double GetSpeed()
    {
        return _distance / GetMinutes() * 60;
    }

    protected override double GetPace()
    {
        return GetMinutes() / _distance;
    }

    protected override string GetActivityType()
    {
        return "Biking";
    }
}