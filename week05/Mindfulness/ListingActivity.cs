using System;
using System.Collections.Generic;

// Listing activity class
public class ListingActivity : MindfulnessActivity
{
    private readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    protected override void RunActivity(int duration)
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Length)]);
        Console.WriteLine("Begin listing items...");
        Pause(5);
        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Write("Enter an item (or press enter to finish): ");
            string item = Console.ReadLine();
            if (string.IsNullOrEmpty(item)) break;
            items.Add(item);
        }
        Console.WriteLine($"You listed {items.Count} items.");
    }
}