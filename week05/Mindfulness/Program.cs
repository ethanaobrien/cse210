/* Author: Ethan O'Brien
 * Assignment: W05 Project: Mindfulness Program
 * 
 * Extra:
 *  - All methods in Activity are "protected", rather than public. This makes more sense for the use case.
 *  - The amount of times you did each activity is printed when leaving.
 */

class Program
{
    static void Main(string[] args)
    {
        var lastOptionInvalid = false;
        var running = true;
        var activities = new Dictionary<string, int>()
        {
            {"breathing", 0},
            {"reflecting", 0},
            {"listing", 0}
        };
        while (running)
        {
            Console.Clear();
            if (lastOptionInvalid)
            {
                Console.WriteLine("Invalid option.");
                Console.WriteLine();
            }
            Console.WriteLine("Menu options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select an option: ");
            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    new BreathingActivity().Run();
                    activities["breathing"]++;
                    break;
                case '2':
                    new ReflectingActivity().Run();
                    activities["reflecting"]++;
                    break;
                case '3':
                    new ListingActivity().Run();
                    activities["listing"]++;
                    break;
                case '4':
                    running = false;
                    break;
                default:
                    lastOptionInvalid = true;
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("Nice job today!");
        Console.WriteLine("You completed:");
        var breathingCount = activities["breathing"] == 0 ? "No" : activities["breathing"].ToString();
        Console.WriteLine($"  {breathingCount} Breathing activities");
        var reflectingCount = activities["reflecting"] == 0 ? "No" : activities["reflecting"].ToString();
        Console.WriteLine($"  {reflectingCount} Reflecting activities");
        var listingCount = activities["listing"] == 0 ? "No" : activities["listing"].ToString();
        Console.WriteLine($"  {listingCount} Listing activities");
        
        var total =  activities["breathing"] + activities["reflecting"] + activities["listing"];
        var totalCount = total == 0 ? "no" : total.ToString();

        Console.WriteLine();
        Console.WriteLine($"That's {totalCount} activities in total!");

    }
}