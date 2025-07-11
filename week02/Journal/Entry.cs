
public class Entry
{
    public string _date { get; init; }
    public string _promptText { get; init; }
    public string _entryText { get; init; }
    
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - {_promptText}");
        Console.WriteLine(_entryText);
    }
}
