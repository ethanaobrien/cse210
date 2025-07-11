/**
 * Author: Ethan O'Brien
 * Assignment: Project: Journal Program
 *
 * Extra:
 * - Choice validation. The text you input must be a number and a number from 1-5
 * - Used an enum. I used an enum to avoid "magic numbers" in the code for each type of code.
 * - Save to JSON. I used the system "System.Text.Json" namespace to save/load from a file. This was more of a pain than I thought it would be..
 */

class Program
{
    private enum Commands 
    {
        NewEntry = 1,
        DisplayEntries = 2,
        SaveEntries = 3,
        LoadEntries = 4,
        Exit = 5
    }

    private static readonly List<string> _successCodes =
    [
        "Entry saved to journal!",
        "Entries displayed.",
        "Journal saved to file!",
        "Journal loaded from file!"
    ];
    private static Journal _journal;

    private static void Main(string[] args)
    {
        var running = true;
        _journal = new Journal();
        var lastOption = 0;
        while (running)
        {
            Console.Clear();
            if (lastOption < 0)
            {
                Console.WriteLine("Invalid choice! Please enter a valid option.");
                Console.WriteLine();
            }
            
            if (lastOption > 0 && lastOption <= _successCodes.Count)
            {
                Console.WriteLine(_successCodes[lastOption - 1]);
                Console.WriteLine();
            }
            
            Console.WriteLine("Please choose an option (1-5)");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save to a file");
            Console.WriteLine("4. Load from a file");
            Console.WriteLine("5. Exit");
            var text = Console.ReadLine();
            if (int.TryParse(text, out var outChoice) && outChoice is >= 1 and <= 5)
            {
                lastOption = outChoice;
                var result = (Commands) outChoice;
                switch (result)
                {
                    case Commands.NewEntry:
                        NewEntry();
                        break;
                    case Commands.DisplayEntries:
                        DisplayEntries();
                        break;
                    case Commands.SaveEntries:
                        SaveEntries();
                        break;
                    case Commands.LoadEntries:
                        LoadEntries();
                        break;
                    case Commands.Exit:
                        running = false;
                        break;
                }
            }
            else
            {
                lastOption = -1;
            }
        }
    }

    private static void NewEntry()
    {
        var prompt = new PromptGenerator().GetRandomPrompt();
        
        Console.Clear();
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.Write("> ");
        
        var response = Console.ReadLine();
        var entry = new Entry
        {
            _date = DateTime.Now.ToString("MMMM dd, yyyy"),
            _promptText = prompt,
            _entryText = response
        };
        _journal.AddEntry(entry);
    }

    private static void DisplayEntries()
    {
        _journal.DisplayAll();
        
        Console.WriteLine();
        Console.WriteLine("Press enter to go back to home...");
        Console.ReadLine();
    }

    private static void SaveEntries()
    {
        Console.Clear();
        Console.Write("Please enter a file name to save to: ");
        var file = Console.ReadLine();
        _journal.SaveToFile(file);
    }

    private static void LoadEntries()
    {
        Console.Clear();
        Console.Write("Please enter a file name to load from: ");
        var file = Console.ReadLine();
        _journal.LoadFromFile(file);
    }
}
