/*
 * Author: Ethan O'Brien
 * Assignment: Scripture Memorizer Program
 *
 * Extras:
 *  - Will always show symbols (such as ' " ? . ,)
 *  - Chooses from multiple verses at the start of the program
 *  - Will choose a "difficulty" at the start, and will hide 1-3 words at a time.
 */

class Program
{
    
    static void Main(string[] args)
    {
        var choice = ScriptureChooser.GetRandomScripture();
        var reference = choice.ToReference();
        var verse = choice.GetScripture();
        var scripture = new Scripture(reference, verse);
        var difficulty = new Random().Next(1, 3);

        while (true)
        {
            Console.Clear();
            Console.Write(reference.GetDisplayText());
            Console.Write(": ");
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press enter to continue or 'quit' to finish.");
            var input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("Good job! You finished!");
                break;
            }

            scripture.HideRandomWords(difficulty);
        }
    }
}