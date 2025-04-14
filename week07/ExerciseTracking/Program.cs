using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a list to hold different activity types
            List<Activity> activities = new List<Activity>();

            // Create instances of each activity
            activities.Add(new Running(new DateTime(2025, 4, 14), 30, 3.0));
            activities.Add(new Cycling(new DateTime(2025, 4, 14), 45, 15.0));
            activities.Add(new Swimming(new DateTime(2025, 4, 14), 25, 20));

            activities.Add(new Running(new DateTime(2025, 4, 13), 40, 4.5));
            activities.Add(new Cycling(new DateTime(2025, 4, 13), 60, 18.0));
            activities.Add(new Swimming(new DateTime(2025, 4, 13), 30, 30));

            // Iterate through the list and display the summary of each activity
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}