namespace EternalQuest
{
    // Simple goal that is completed once
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

        public override void RecordEvent()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                Console.WriteLine($"Congratulations! You completed the goal: {Name}. You earned {Points} points.");
            }
            else
            {
                Console.WriteLine($"You have already completed the goal: {Name}.");
            }
        }

        public override void Display()
        {
            Console.Write($"[{(IsComplete ? "X" : " ")}] {Name} ({Description})");
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{Name}:{Description}:{Points}:{IsComplete}";
        }
    }
}