using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = [];

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        Console.Clear();
        foreach (var entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(String fileName)
    {
        var json = JsonSerializer.Serialize(_entries);
        File.WriteAllText(fileName, json);
    }

    public void LoadFromFile(String fileName)
    {
        var json = File.ReadAllText(fileName);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json);
    }
}