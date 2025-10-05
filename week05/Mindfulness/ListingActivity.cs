using System;
using System.Collections.Generic;

namespace Mindfulness
{
    /// <summary>
    /// Listing activity that helps users reflect on positive aspects of their life.
    /// Inherits from Activity base class.
    /// </summary>
    public class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts = new List<string>();

        /// <summary>
        /// Constructor for the ListingActivity class.
        /// Initializes the prompts list.
        /// </summary>
        public ListingActivity() : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
        {
            _count = 0;
            InitializePrompts();
        }

        /// <summary>
        /// Initializes the list of listing prompts.
        /// </summary>
        private void InitializePrompts()
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        /// <summary>
        /// Gets a random prompt from the prompts list.
        /// </summary>
        /// <returns>A random prompt string</returns>
        public string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
        }

        /// <summary>
        /// Collects a list of items from the user until the specified duration is reached.
        /// </summary>
        /// <returns>A list of strings entered by the user</returns>
        public List<string> GetListFromUser()
        {
            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                    _count++;
                }
            }

            return items;
        }

        /// <summary>
        /// Runs the listing activity with prompts and user input collection.
        /// </summary>
        public override void Run()
        {
            DisplayStartingMessage();
            
            string prompt = GetRandomPrompt();
            Console.WriteLine($"List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            
            List<string> items = GetListFromUser();
            
            Console.WriteLine($"You listed {_count} items!");
            
            DisplayEndingMessage();
        }
    }
}
