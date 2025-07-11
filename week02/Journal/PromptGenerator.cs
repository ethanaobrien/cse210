
public class PromptGenerator
{
    private List<string> _prompts =
    [
        "Did anyone anger you today?",
        "What was the best part of your day?",
        "Are you keeping in touch with your friends?",
        "How did you receive help from spirit today?",
        "If you could change something about your day, what would it be?"
    ];

    public string GetRandomPrompt()
    {
        var rnd = new Random();
        return _prompts[rnd.Next(0, _prompts.Count)];
    }
}