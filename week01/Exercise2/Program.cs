using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade number? ");
        var input = Console.ReadLine();
        var grade = int.Parse(input);

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        var minorValue = grade % 10;
        var sign = "";
        if (minorValue >= 7)
        {
            sign = "+";
        }
        else if (minorValue < 3)
        {
            sign = "-";
        }
        var gradeSignLetter = $"{letter}{sign}";
        if (gradeSignLetter == "A+" || letter == "F" || grade >= 100)
        {
            gradeSignLetter = letter;
        }

        Console.WriteLine($"Your grade is: {letter}");

        var a = letter == "A" || letter == "E" || letter == "F" ? "an" : "a";
        Console.WriteLine($"You have {a}: {gradeSignLetter}");
        
        if (grade >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You did not pass!");
        }

        //Console.WriteLine("Hello World! This is the Exercise2 Project.");
    }
}