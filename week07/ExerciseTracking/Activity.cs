

public abstract class Activity
{
    protected DateTime _startDate;
    protected DateTime _endDate;

    protected Activity(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    protected abstract double GetDistance();
    protected abstract double GetSpeed();
    protected abstract double GetPace();

    protected abstract string GetActivityType();

    protected double GetMinutes()
    {
        var duration = _endDate.Subtract(_startDate);
        return duration.TotalMinutes;
    }

    public virtual string GetSummary()
    {
        var date = _startDate.ToString("dd MMM yyyy");
        
        return $"{date} {GetActivityType()} ({GetMinutes()} min)- Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}