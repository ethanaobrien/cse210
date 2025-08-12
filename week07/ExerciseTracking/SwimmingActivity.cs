
public class SwimmingActivity: Activity
{
    private int _laps;
    
    public SwimmingActivity(DateTime startDate, DateTime endDate, int laps) :
        base(startDate, endDate)
    {
        _laps = laps;
    }

    protected override double GetDistance()
    {
        return _laps * 50 / 1000.0 * 0.62;
    }

    protected override double GetSpeed()
    {
        return GetDistance() / GetMinutes() * 60;
    }

    protected override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }

    protected override string GetActivityType()
    {
        return "Swimming";
    }

    public override string GetSummary()
    {
        var date = _startDate.ToString("dd MMM yyyy");
        
        return $"{date} {GetActivityType()} ({GetMinutes()} min)- Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile, Laps: {_laps}";
    }
}