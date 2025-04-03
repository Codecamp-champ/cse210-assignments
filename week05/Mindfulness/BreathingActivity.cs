using System;

// Breathing activity class
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void RunActivity(int duration)
    {
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);
            if ((DateTime.Now - startTime).TotalSeconds >= duration) break;
            Console.WriteLine("Breathe out...");
            Pause(3);
        }
    }
}