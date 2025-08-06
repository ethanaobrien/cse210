
using System.Diagnostics;

public class SimpleGoal: Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points):
        base(name, description, points)
    {
        
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override int RecordFailedEvent()
    {
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override void Reset()
    {
        _isComplete = false;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }

    public static SimpleGoal FromStringRepresentation(string goal)
    {
        var title = goal.Split(':')[0];
        Debug.Assert(title == "SimpleGoal");
        var goalDetails = goal[(title.Length + 1)..].Split(',');
        var rvGoal = new SimpleGoal(
            goalDetails[0],
            goalDetails[1],
            int.Parse(goalDetails[2])
        )
        {
            _isComplete = goalDetails[3] == "true"
        };
        return rvGoal;
    }
}
