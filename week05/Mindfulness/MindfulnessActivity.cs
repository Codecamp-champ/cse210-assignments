using System;
using System.Threading;

// Base class for all mindfulness activities
public abstract class MindfulnessActivity
{
    protected string Name { get; }
    protected string Description { get; }

    protected MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity()
    {
        int duration = GetDuration();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
        RunActivity(duration);
        EndActivity(duration);
    }

    protected int GetDuration()
    {
        Console.WriteLine($"Welcome to {Name}!\n{Description}\nHow many seconds would you like to do this activity?");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
        return duration;
    }

    protected void EndActivity(int duration)
    {
        Console.WriteLine("Great job!");
        Pause(2);
        Console.WriteLine($"You have completed {Name} for {duration} seconds.");
        Pause(2);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"Pausing... {i}  \r"); // Added extra spaces to overwrite the numbers
            Thread.Sleep(1000);
        }
        Console.WriteLine(new string(' ', 15)); // Clear the line with spaces
    }

    protected abstract void RunActivity(int duration);
}