using System;

class Program
{
    static void Main(string[] args)
    {
        var rnd = new Random();
        var magicNumber = rnd.Next(1, 101);

        var guess = 0;
        var guessCount = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {guessCount} guesses!");
            }
        }
    }
}