using System;
using Resumes;

class Program
{
    static void Main(string[] args)
    {
        var person = new Resume();
        var job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;
        var job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;
        person._name = "Allison Rose";
        person._jobs.Add(job1);
        person._jobs.Add(job2);
        person.Display();
    }
}