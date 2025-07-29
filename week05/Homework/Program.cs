using System;

class Program
{
    private static void Main(string[] args)
    {
        var a1 = new Assignment("Billy Bob", "Lunchtime");
        Console.WriteLine(a1.GetSummary());

        var a2 = new MathAssignment("Steve Jones", "Multiplication", "9.16", "1-20");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        var a3 = new WritingAssignment("Jane Doe", "Personal Narrative", "The moment that changed your life");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}