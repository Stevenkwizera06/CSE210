using System;

class Program
{
    static void Main(string[] args)
    {
        // Display initial message
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        
        // Prompt for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine() ?? "";
        
        // Prompt for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine() ?? "";
        
        // Display the result in James Bond format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}

