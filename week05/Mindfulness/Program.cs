using System;

namespace Mindfulness
{
    /// <summary>
    /// Main program class for the Mindfulness Program.
    /// Provides a menu system to allow users to choose from different mindfulness activities.
    /// 
    /// CREATIVITY FEATURES TO EXCEED REQUIREMENTS:
    /// 1. Activity Statistics Tracking - Tracks how many times each activity has been performed
    /// 2. Session Logging - Logs each session with timestamp and duration
    /// 3. Enhanced Breathing Animation - More realistic breathing visualization with growing/shrinking text
    /// 4. Activity Recommendations - Suggests activities based on usage patterns
    /// 5. Session Summary - Provides a summary of completed activities at the end
    /// </summary>
    class Program
    {
        private static int breathingCount = 0;
        private static int reflectingCount = 0;
        private static int listingCount = 0;
        private static List<SessionLog> sessionLogs = new List<SessionLog>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine();
            
            bool continueProgram = true;
            
            while (continueProgram)
            {
                DisplayMenu();
                string? choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        RunBreathingActivity();
                        break;
                    case "2":
                        RunReflectingActivity();
                        break;
                    case "3":
                        RunListingActivity();
                        break;
                    case "4":
                        DisplayStatistics();
                        break;
                    case "5":
                        DisplaySessionLog();
                        break;
                    case "6":
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            
            DisplaySessionSummary();
            Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
        }

        /// <summary>
        /// Displays the main menu options.
        /// </summary>
        static void DisplayMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View activity statistics");
            Console.WriteLine("5. View session log");
            Console.WriteLine("6. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");
        }

        /// <summary>
        /// Runs the breathing activity and tracks statistics.
        /// </summary>
        static void RunBreathingActivity()
        {
            BreathingActivity breathingActivity = new BreathingActivity();
            DateTime startTime = DateTime.Now;
            
            breathingActivity.Run();
            
            DateTime endTime = DateTime.Now;
            int duration = (int)(endTime - startTime).TotalSeconds;
            
            breathingCount++;
            sessionLogs.Add(new SessionLog("Breathing Activity", duration, DateTime.Now));
            
            Console.WriteLine($"Breathing activity completed! (Session #{breathingCount})");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Runs the reflecting activity and tracks statistics.
        /// </summary>
        static void RunReflectingActivity()
        {
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            DateTime startTime = DateTime.Now;
            
            reflectingActivity.Run();
            
            DateTime endTime = DateTime.Now;
            int duration = (int)(endTime - startTime).TotalSeconds;
            
            reflectingCount++;
            sessionLogs.Add(new SessionLog("Reflecting Activity", duration, DateTime.Now));
            
            Console.WriteLine($"Reflecting activity completed! (Session #{reflectingCount})");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Runs the listing activity and tracks statistics.
        /// </summary>
        static void RunListingActivity()
        {
            ListingActivity listingActivity = new ListingActivity();
            DateTime startTime = DateTime.Now;
            
            listingActivity.Run();
            
            DateTime endTime = DateTime.Now;
            int duration = (int)(endTime - startTime).TotalSeconds;
            
            listingCount++;
            sessionLogs.Add(new SessionLog("Listing Activity", duration, DateTime.Now));
            
            Console.WriteLine($"Listing activity completed! (Session #{listingCount})");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays activity statistics to the user.
        /// </summary>
        static void DisplayStatistics()
        {
            Console.Clear();
            Console.WriteLine("Activity Statistics:");
            Console.WriteLine($"Breathing Activities Completed: {breathingCount}");
            Console.WriteLine($"Reflecting Activities Completed: {reflectingCount}");
            Console.WriteLine($"Listing Activities Completed: {listingCount}");
            Console.WriteLine($"Total Sessions: {sessionLogs.Count}");
            
            if (sessionLogs.Count > 0)
            {
                int totalTime = sessionLogs.Sum(log => log.Duration);
                Console.WriteLine($"Total Time Spent: {totalTime} seconds ({totalTime / 60} minutes)");
                
                // Activity recommendations based on usage
                Console.WriteLine();
                Console.WriteLine("Activity Recommendations:");
                if (breathingCount < reflectingCount && breathingCount < listingCount)
                {
                    Console.WriteLine("💡 Consider trying more breathing activities for relaxation!");
                }
                if (reflectingCount < breathingCount && reflectingCount < listingCount)
                {
                    Console.WriteLine("💡 Consider trying more reflecting activities for self-discovery!");
                }
                if (listingCount < breathingCount && listingCount < reflectingCount)
                {
                    Console.WriteLine("💡 Consider trying more listing activities for gratitude!");
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the session log with timestamps and durations.
        /// </summary>
        static void DisplaySessionLog()
        {
            Console.Clear();
            Console.WriteLine("Session Log:");
            Console.WriteLine();
            
            if (sessionLogs.Count == 0)
            {
                Console.WriteLine("No sessions completed yet.");
            }
            else
            {
                foreach (var log in sessionLogs.OrderByDescending(l => l.Timestamp))
                {
                    Console.WriteLine($"{log.Timestamp:yyyy-MM-dd HH:mm:ss} - {log.ActivityName} ({log.Duration}s)");
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays a summary of the current session when the program ends.
        /// </summary>
        static void DisplaySessionSummary()
        {
            if (sessionLogs.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Session Summary:");
                Console.WriteLine($"Total Activities Completed: {sessionLogs.Count}");
                Console.WriteLine($"Breathing: {breathingCount} | Reflecting: {reflectingCount} | Listing: {listingCount}");
                
                int totalTime = sessionLogs.Sum(log => log.Duration);
                Console.WriteLine($"Total Time: {totalTime / 60} minutes {totalTime % 60} seconds");
                Console.WriteLine();
                Console.WriteLine("Great job taking time for mindfulness today! 🌟");
            }
        }
    }

    /// <summary>
    /// Represents a session log entry for tracking activity usage.
    /// </summary>
    public class SessionLog
    {
        public string ActivityName { get; set; }
        public int Duration { get; set; }
        public DateTime Timestamp { get; set; }

        public SessionLog(string activityName, int duration, DateTime timestamp)
        {
            ActivityName = activityName;
            Duration = duration;
            Timestamp = timestamp;
        }
    }
}
