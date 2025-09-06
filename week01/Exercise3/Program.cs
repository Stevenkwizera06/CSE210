using System;

class Program
{
    static void Main(string[] args)
    {
        // For Parts 1 and 2, where the user specified the number...
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        
        // For Part 3, where we use a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int guessCount = 0;

        // We could also use a do-while loop here...
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine() ?? "";
            
            // Check if input is valid number
            if (int.TryParse(input, out guess))
            {
                guessCount++;
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

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

        // Ask if they want to play again
        Console.Write("Do you want to play again? (yes/no): ");
        string playAgain = Console.ReadLine() ?? "";
        
        if (playAgain == "yes")
        {
            // Restart the game by calling Main recursively
            Main(args);
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
        }
    }
}
