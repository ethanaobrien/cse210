
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();

    public abstract int RecordFailedEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    public abstract void Reset();

    public string GetName()
    {
        return _shortName;
    }

    public abstract string GetStringRepresentation();
}
