using System;

namespace Mindfulness
{
    /// <summary>
    /// Base class for all mindfulness activities.
    /// Contains shared attributes and behaviors for breathing, reflection, and listing activities.
    /// </summary>
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        /// <summary>
        /// Constructor for the Activity class.
        /// </summary>
        /// <param name="name">The name of the activity</param>
        /// <param name="description">Description of what the activity does</param>
        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        /// <summary>
        /// Displays the starting message with activity name, description, and prompts for duration.
        /// </summary>
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            
            // Get duration from user
            while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }
            
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        /// <summary>
        /// Displays the ending message after activity completion.
        /// </summary>
        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(3);
        }

        /// <summary>
        /// Shows a spinner animation for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds to show the spinner</param>
        public void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            int spinnerIndex = 0;
            
            for (int i = 0; i < seconds * 4; i++) // 4 frames per second
            {
                Console.Write($"\r{spinner[spinnerIndex]}");
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
                Thread.Sleep(250);
            }
            Console.Write("\r \r"); // Clear the spinner
        }

        /// <summary>
        /// Shows a countdown timer for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">Number of seconds to count down</param>
        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\r{i}");
                Thread.Sleep(1000);
            }
            Console.Write("\r \r"); // Clear the countdown
        }

        /// <summary>
        /// Abstract method that must be implemented by derived classes.
        /// Contains the specific logic for each activity type.
        /// </summary>
        public abstract void Run();
    }
}
