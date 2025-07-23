
public class Comment
{
    private string _text;
    private readonly string _person;

    public Comment(string text, string person)
    {
        _text = text;
        _person = person;
    }
    
    public string GetComment()
    {
        return _text;
    }

    public string GetPerson()
    {
        return _person;
    }

    public void EditComment(string text)
    {
        _text = text;
    }

    public void Display()
    {
        Console.WriteLine($"{_person}:  {_text}");
    }
}