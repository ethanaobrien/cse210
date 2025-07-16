
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = startVerse;
    }
    
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }
    
    public string GetDisplayText()
    {
        var text = _book + " " + _chapter + ":" + _verse;
        if (_endVerse != _verse)
        {
            text += "-" + _endVerse;
        }
        return text;
    }
}