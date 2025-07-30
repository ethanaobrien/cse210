
public class Activity
{
    private readonly string _name;
    private readonly string _description;
    protected int _duration { get; private set; }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(3);
        
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("Nice job!!");
        ShowSpinner(5);
        
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(6);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> spinnerSymbols = ["-", "\\", "|", "/"];
        const int time = 250;
        
        for (var i = 0; i < seconds / (time / 1000.0); i++)
        {
            var symbol = spinnerSymbols[i % spinnerSymbols.Count];
            Console.Write(symbol);
            Thread.Sleep(time);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (var i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            var len = i.ToString().Length;
            Console.Write(new string('\b', len));
            Console.Write(new string(' ', len));
            Console.Write(new string('\b', len));
        }
    }
}