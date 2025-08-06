
using System.Diagnostics;

public class EternalGoal: Goal
{
    public EternalGoal(string name, string description, int points):
        base(name, description, points)
    {
        
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override int RecordFailedEvent()
    {
        return 0;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override void Reset() {}

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
    
    public static EternalGoal FromStringRepresentation(string goal)
    {
        var title = goal.Split(':')[0];
        Debug.Assert(title == "EternalGoal");
        var goalDetails = goal[(title.Length + 1)..].Split(',');
        var rvGoal = new EternalGoal(
            goalDetails[0],
            goalDetails[1],
            int.Parse(goalDetails[2])
        );
        return rvGoal;
    }
}
