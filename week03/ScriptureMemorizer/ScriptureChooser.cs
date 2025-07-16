
public class ScriptureChooser
{
    public struct ScriptureReference(string scripture, string book, int chapter, int verse, int endVerse = -1)
    {
        private string _scripture = scripture;
        private int _verse = verse;
        private int _endVerse = endVerse == -1 ? verse : endVerse;
        private int _chapter = chapter;
        private string _book = book;

        public Reference ToReference()
        {
            return new Reference(_book, _chapter, _verse, _endVerse);
        }

        public string GetScripture()
        {
            return _scripture;
        }
    }
    private static List<ScriptureReference> _scriptures =
    [
        new ScriptureReference(
            "But behold, these which thine eyes are upon shall perish in the floods; and behold, I will shut them up; a prison have I prepared for them.",
            "Moses",
            30,
            7),
        new ScriptureReference(
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
            "Proverbs",
            3,
            5,
            6),
        new ScriptureReference(
            "And, if you keep my commandments and endure to the end you shall have eternal life, which gift is the greatest of all the gifts of God.",
            "Doctrine and Covenants",
            14,
            7)
    ];

    public static ScriptureReference GetRandomScripture()
    {
        return _scriptures[new Random().Next(_scriptures.Count)];
    }
    
}