using System;
using System.Collections.Generic;

namespace Mindfulness
{
    /// <summary>
    /// Reflection activity that guides users to think deeply about their experiences.
    /// Inherits from Activity base class.
    /// </summary>
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>();
        private List<string> _questions = new List<string>();

        /// <summary>
        /// Constructor for the ReflectingActivity class.
        /// Initializes the prompts and questions lists.
        /// </summary>
        public ReflectingActivity() : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        )
        {
            InitializePrompts();
            InitializeQuestions();
        }

        /// <summary>
        /// Initializes the list of reflection prompts.
        /// </summary>
        private void InitializePrompts()
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };
        }

        /// <summary>
        /// Initializes the list of reflection questions.
        /// </summary>
        private void InitializeQuestions()
        {
            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
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
        /// Gets a random question from the questions list.
        /// </summary>
        /// <returns>A random question string</returns>
        public string GetRandomQuestion()
        {
            Random random = new Random();
            return _questions[random.Next(_questions.Count)];
        }

        /// <summary>
        /// Displays a selected prompt to the user.
        /// </summary>
        /// <param name="prompt">The prompt to display</param>
        public void DisplayPrompt(string prompt)
        {
            Console.WriteLine($"Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
        }

        /// <summary>
        /// Displays a series of questions to the user with pauses between them.
        /// </summary>
        /// <param name="endTime">The time when the activity should end</param>
        public void DisplayQuestions(DateTime endTime)
        {
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.WriteLine(question);
                ShowSpinner(5); // 5 seconds to think about each question
            }
        }

        /// <summary>
        /// Runs the reflection activity with prompts and questions.
        /// </summary>
        public override void Run()
        {
            DisplayStartingMessage();
            
            string prompt = GetRandomPrompt();
            DisplayPrompt(prompt);
            
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            
            DisplayQuestions(endTime);
            
            DisplayEndingMessage();
        }
    }
}
