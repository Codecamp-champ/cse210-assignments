using System;

namespace EternalQuest
{
    // Eternal goal that can be recorded multiple times
    public class EternalGoal : Goal
    {
        private int _recordCount;

        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
            _recordCount = 0;
        }

        public override void RecordEvent()
        {
            _recordCount++;
            Console.WriteLine($"You recorded progress on the eternal goal: {Name}. You earned {Points} points.");
        }

        public override void Display()
        {
            Console.Write($"[ ] {Name} ({Description}) - Recorded {_recordCount} times");
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{Name}:{Description}:{Points}:{_recordCount}";
        }
    }
}