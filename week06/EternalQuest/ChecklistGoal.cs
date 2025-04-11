using System;

namespace EternalQuest
{
    // Checklist goal that needs to be completed a certain number of times
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        public int TimesNeeded { get; set; }
        public int BonusPoints { get; set; }

        public ChecklistGoal(string name, string description, int points, int timesNeeded, int bonusPoints) : base(name, description, points)
        {
            TimesNeeded = timesNeeded;
            BonusPoints = bonusPoints;
            _timesCompleted = 0;
        }

        public override void RecordEvent()
        {
            _timesCompleted++;
            Console.WriteLine($"You recorded progress on the checklist goal: {Name}. You earned {Points} points.");
            if (_timesCompleted == TimesNeeded)
            {
                IsComplete = true;
                Points += BonusPoints; // Add bonus points upon completion
                Console.WriteLine($"Congratulations! You completed the checklist goal: {Name}. You earned an additional {BonusPoints} bonus points!");
            }
        }

        public override void Display()
        {
            Console.Write($"[{(IsComplete ? "X" : " ")}] {Name} ({Description}) - Completed {_timesCompleted}/{TimesNeeded} times");
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{Name}:{Description}:{Points}:{TimesNeeded}:{BonusPoints}:{_timesCompleted}";
        }
    }
}