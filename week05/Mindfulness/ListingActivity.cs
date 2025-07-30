

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
        // Nothing is needed here
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();
        var userInput = GetListFromUser();
        Console.WriteLine($"You listed {userInput.Count} things!");
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        var prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($" --- {prompt} --- ");
    }

    private List<string> GetListFromUser()
    {
        List<string> userInput = [];
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine("GO!");
        
        var endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            userInput.Add(Console.ReadLine());
        }
        return userInput;
    }
}