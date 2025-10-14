using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2022, 11, 3), 30, 6.0),
                new Swimming(new DateTime(2022, 11, 3), 30, 40)
            };

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}


