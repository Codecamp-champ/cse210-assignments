using System;

namespace EternalQuest
{
    // Base class for all goals
    public abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool IsComplete { get; set; }

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            IsComplete = false;
        }

        public abstract void RecordEvent();
        public abstract void Display();
        public abstract string GetStringRepresentation();
    }
}