using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        var lastNumber = -1;
        var list = new List<int>();
        var total = 0;
        var largest = 0;
        var smallestPositive = 0;
        while (lastNumber != 0)
        {
            Console.Write("Enter number: ");
            lastNumber = int.Parse(Console.ReadLine());
            if (lastNumber == 0)
            {
                break;
            }
            list.Add(lastNumber);
            total += lastNumber;
            if (largest < lastNumber || largest == 0)
            {
                largest = lastNumber;
            }
            if ((smallestPositive > lastNumber || smallestPositive == 0) && lastNumber > 0)
            {
                smallestPositive = lastNumber;
            }
        }

        Console.WriteLine($"The sum is: {total}");
        var average = total / list.Count;
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("Here is the sorted list:");
        list.Sort();
        var first = true;
        foreach (var num in list)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                Console.Write(", ");
            }
            Console.Write(num);
        }
        Console.WriteLine("");
    }
}
