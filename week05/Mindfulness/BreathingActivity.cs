using System;

namespace Mindfulness
{
    /// <summary>
    /// Breathing activity that helps users relax through guided breathing exercises.
    /// Inherits from Activity base class.
    /// </summary>
    public class BreathingActivity : Activity
    {
        /// <summary>
        /// Constructor for the BreathingActivity class.
        /// </summary>
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
        {
        }

        /// <summary>
        /// Runs the breathing activity with alternating breathe in/out messages.
        /// </summary>
        public override void Run()
        {
            DisplayStartingMessage();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            
            bool breatheIn = true;
            
            while (DateTime.Now < endTime)
            {
                if (breatheIn)
                {
                    Console.WriteLine("Breathe in...");
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                }
                
                ShowCountDown(4); // 4 seconds for each breath phase
                breatheIn = !breatheIn;
            }
            
            DisplayEndingMessage();
        }
    }
}
