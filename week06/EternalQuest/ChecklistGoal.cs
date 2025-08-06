
using System.Diagnostics;

public class ChecklistGoal: Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private int _minusPoints;
    private int _failedCount;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int minusPoints) :
        base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _minusPoints = minusPoints;
        _amountCompleted = 0;
        _failedCount = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            return _points +  _bonus;
        }
        return _points;
    }

    public override int RecordFailedEvent()
    {
        if (_minusPoints > 0) _failedCount++;
        return _minusPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override void Reset()
    {
        _amountCompleted = 0;
    }

    public override string GetDetailsString()
    {
        var details =  $"{_shortName} ({_description}) - Currently Completed: {_amountCompleted}/{_target}";
        if (_minusPoints > 0)
        {
            details += $" - Failed: {_failedCount} times.";
        }
        return details;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_minusPoints},{_amountCompleted},{_failedCount}";
    }

    public static ChecklistGoal FromStringRepresentation(string goal)
    {
        var title = goal.Split(':')[0];
        Debug.Assert(title == "ChecklistGoal");
        var goalDetails = goal[(title.Length + 1)..].Split(',');
        var rvGoal = new ChecklistGoal(
            goalDetails[0],
            goalDetails[1],
            int.Parse(goalDetails[2]),
            int.Parse(goalDetails[3]),
            int.Parse(goalDetails[4]),
            int.Parse(goalDetails[5])
        )
        {
            _amountCompleted = int.Parse(goalDetails[6]),
            _failedCount = int.Parse(goalDetails[7]),
        };

        return rvGoal;
    }
}
