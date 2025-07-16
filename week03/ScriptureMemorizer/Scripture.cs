
public class Scripture
{
    private Reference _reference;
    private List<Word> _words = [];

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (var word in text.Trim().Split(' '))
        {
            if (word == "")
            {
                continue;
            }
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        var rnd = new Random();
        var words = _words.Where(word => !word.IsHidden()).ToList();
        for (var i = 0; i < numberToHide; i++)
        {
            //Console.WriteLine("word hidden");
            var index = rnd.Next(1, words.Count);
            words[index - 1].Hide();
        }
    }

    public string GetDisplayText()
    {
        var text = _words.Aggregate("", (current, word) => current + (word.GetDisplayText() + " "));
        text.Remove(text.Length -1);
        return text;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}