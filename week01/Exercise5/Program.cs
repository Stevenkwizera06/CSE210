using System;

class Program
{
    static void Main(string[] args)
    {
        // Call each function and save return values
        DisplayWelcome();
        
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        
        DisplayResult(userName, squaredNumber);
    }
    
    // Displays the message, "Welcome to the Program!"
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    
    // Asks for and returns the user's name (as a string)
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine() ?? "";
        return name;
    }
    
    // Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine() ?? "0";
        
        // Handle invalid input
        while (!int.TryParse(input, out int number))
        {
            Console.WriteLine("Please enter a valid number.");
            Console.Write("Please enter your favorite number: ");
            input = Console.ReadLine() ?? "0";
        }
        
        return int.Parse(input);
    }
    
    // Accepts an integer as a parameter and returns that number squared (as an integer)
    static int SquareNumber(int number)
    {
        return number * number;
    }
    
    // Accepts the user's name and the squared number and displays them
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
