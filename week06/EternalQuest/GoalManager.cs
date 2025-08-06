
public class GoalManager
{
    private List<Goal> _goals = [];
    private int _score = 0;

    public void Start()
    {
        var running = true;
        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Main menu:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Record Failed Event");
            Console.WriteLine("  7. Quit");
            Console.Write("> ");
            var choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    RecordFailedEvent();
                    break;
                case 7:
                    running = false;
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        var count = 1;
        foreach (var goal in _goals)
        {
            var name = goal.GetName();
            Console.WriteLine($"{count}. {name}");
            count++;
        }
    }

    private void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("The goals are:");
        var count = 1;
        foreach (var goal in _goals)
        {
            var completed = goal.IsComplete() ? "X" : " ";
            var details = goal.GetDetailsString();
            Console.WriteLine($"{count}. [{completed}] {details}");
            count++;
        }
        Console.Write("Press enter to go back to home");
        Console.ReadLine();
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create?: ");
        var choice = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is the name of your goal? ");
        var name =  Console.ReadLine().Replace(",", "");
        Console.Write("What is a description of your goal? ");
        var description = Console.ReadLine().Replace(",", "");
        Console.Write("What amount of points are associated with this goal? ");
        var points = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                var bonusTimes = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                var bonusPoints = int.Parse(Console.ReadLine());
                Console.Write("How many points should you lose if you fail to complete it on your planned schedule? ");
                var losePoints = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, bonusTimes, bonusPoints, losePoints));
                break;
            }
        }
    }

    private static bool WantsRestart()
    {
        while (true)
        {
            Console.WriteLine("You have already completed this goal!");
            Console.Write("Would you like to restart it? (Y/n): ");
            var restart = Console.ReadLine().ToLower();
            switch (restart)
            {
                case "y":
                    return true;
                case "n":
                    return false;
            }
        }
    }

    private void RecordEvent()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created!");
            Console.Write("Press enter to go to home");
            Console.ReadLine();
            return;
        }
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        var choice = Convert.ToInt32(Console.ReadLine()) - 1;
        var goal = _goals[choice];
        if (goal.IsComplete())
        {
            if (WantsRestart())
            {
                goal.Reset();
            }
            else
            {
                Console.WriteLine("You can't mark a completed goal as completed! Cancelling.");
                Console.Write("Press enter to go to home");
                Console.ReadLine();
                return;
            }
        }
        var points = goal.RecordEvent();
        Console.WriteLine($"Congratulations. You have earned {points} points.");
        _score += points;
        Console.WriteLine($"You now have {_score} points.");
        Console.WriteLine();
        Console.Write("Press enter to go to home");
        Console.ReadLine();
    }

    private void RecordFailedEvent()
    {
        Console.Clear();
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created!");
            Console.Write("Press enter to go to home");
            Console.ReadLine();
            return;
        }
        ListGoalNames();
        Console.Write("Which goal did you fail to complete? ");
        var choice = Convert.ToInt32(Console.ReadLine()) - 1;
        var goal = _goals[choice];
        var minusPoints = goal.RecordFailedEvent();
        if (minusPoints == 0)
        {
            Console.WriteLine("This is not a goal you can fail!.");
            Console.Write("Press enter to go to home");
            Console.ReadLine();
            return;
        }
        Console.WriteLine($"You have lost {minusPoints} points.");
        _score -= minusPoints;
        Console.WriteLine($"You now have {_score} points.");
        Console.WriteLine();
        Console.Write("Press enter to go to home");
        Console.ReadLine();
    }

    private void SaveGoals()
    {
        Console.Clear();
        var contents = _score + "\n";
        
        foreach (var goal in _goals)
        {
            contents += goal.GetStringRepresentation();
            contents += "\n";
        }
        
        Console.Write("Please enter a filename to save to: ");
        var filename = Console.ReadLine();
        File.WriteAllText(filename, contents);
        Console.WriteLine($"Goals have been saved to {filename}!");
        Console.Write("Press enter to go to home");
        Console.ReadLine();
    }

    private void LoadGoals()
    {
        Console.Clear();
        Console.Write("Please enter a filename to load from: ");
        var filename = Console.ReadLine();
        var text = File.ReadAllText(filename);
        _goals = [];
        var splits = text.Split('\n');
        _score = int.Parse(splits[0]);
        var goals = text[(splits[0].Length + 1)..].Split('\n');
        foreach (var goalSave in goals)
        {
            if (goalSave.StartsWith("SimpleGoal"))
            {
                _goals.Add(SimpleGoal.FromStringRepresentation(goalSave));
            }
            else if (goalSave.StartsWith("EternalGoal"))
            {
                _goals.Add(EternalGoal.FromStringRepresentation(goalSave));
            }
            else if (goalSave.StartsWith("ChecklistGoal"))
            {
                _goals.Add(ChecklistGoal.FromStringRepresentation(goalSave));
            }
        }
        Console.WriteLine($"{_goals.Count} goals have been loaded!");
        Console.Write("Press enter to go to home");
        Console.ReadLine();
    }
}
