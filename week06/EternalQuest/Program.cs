using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("This program helps you track your goals and earn points for your spiritual journey.");
            Console.WriteLine();

            GoalManager goalManager = new GoalManager();
            goalManager.Start();
        }
    }
}
