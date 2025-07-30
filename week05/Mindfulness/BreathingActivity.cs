

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing"
        )
    {
        // Nothing is needed here?
    }

    public void Run()
    {
        DisplayStartingMessage();
        var endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe In...");
            ShowCountdown(4);

            Console.WriteLine();
            
            Console.Write("Breathe out...");
            ShowCountdown(6);
            
            Console.WriteLine();
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}