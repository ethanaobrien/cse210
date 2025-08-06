using System;
/* Author: Ethan O'Brien
 *  Project: Eternal Quest Program
 *
 * Bonus:
 * - Adds a "failed" goal count, if the user wants, on the "checklist goal".
 * - Before marking a goal as completed, it checks if it has already been completed.
 */

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        manager.Start();
    }
}