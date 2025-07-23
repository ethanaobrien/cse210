
public class Video
{
    private readonly string _title;
    private readonly string _author;
    private readonly int _length;
    private readonly List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = [];
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void Display()
    {
        Console.WriteLine($"Video Title: {_title}");
        Console.WriteLine($"Video Author: {_author}:");
        Console.WriteLine($"Video Length in seconds: {_length}");
        Console.WriteLine("Video Comments:");
        foreach (var comment in _comments)
        {
            Console.Write("  ");
            comment.Display();
        }
    }
}