using System;

class Program
{
    static void Main(string[] args)
    {
        var startDate = DateTime.Parse("03 Nov 2022");
        var endDate = startDate + TimeSpan.FromMinutes(30);
        var activity = new RunningActivity(startDate, endDate, 3.0);
        Console.WriteLine(activity.GetSummary());
        
        var activity1 = new SwimmingActivity(startDate, endDate, 100);
        Console.WriteLine(activity1.GetSummary());
        
        var activity2 = new BikingActivity(startDate, endDate, 5.0);
        Console.WriteLine(activity2.GetSummary());
    }
}