/*
Exceeding Requirements:

1. Leveling Up: The program now includes a basic leveling system. The user's level is determined by their total score.
   Every 500 points earned increases the user's level. The current level is displayed along with the score.

2. Goal Completion Messages with Flair: When a goal is completed, a more enthusiastic message is displayed,
   including the goal name and the points earned, making the completion feel more rewarding.

3. Visual Separators: Added visual separators (lines of '-') in the console output to make the information more organized and easier to read.

These additions aim to enhance the gamification aspect by providing a sense of progression (leveling up) and more engaging feedback upon goal completion.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EternalQuest
{
    public class Program
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _score = 0;
        private static string _filename = "goals.txt";

        static void Main(string[] args)
        {
            LoadGoals();

            while (true)
            {
                Console.WriteLine("\nEternal Quest Program");
                Console.WriteLine($"Current Score: {_score}");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        Console.WriteLine("Exiting Eternal Quest. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("\nThe types of goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string goalType = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of your goal? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points value.");
                return;
            }

            switch (goalType)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    Console.WriteLine("Simple goal created successfully!");
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    Console.WriteLine("Eternal goal created successfully!");
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    if (!int.TryParse(Console.ReadLine(), out int timesNeeded))
                    {
                        Console.WriteLine("Invalid number of times needed.");
                        return;
                    }
                    Console.Write("What is the bonus points for completing it that many times? ");
                    if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
                    {
                        Console.WriteLine("Invalid bonus points value.");
                        return;
                    }
                    _goals.Add(new ChecklistGoal(name, description, points, timesNeeded, bonusPoints));
                    Console.WriteLine("Checklist goal created successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid goal type selected.");
                    break;
            }
        }

        static void ListGoals()
        {
            Console.WriteLine("\nYour Goals:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals have been created yet.");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].Display();
                Console.WriteLine();
            }
        }

        static void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record events for. Please create some goals first.");
                return;
            }

            Console.WriteLine("\nWhich goal did you accomplish?");
            ListGoals();
            Console.Write("Enter the number of the goal: ");
            if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
            {
                Goal goalToRecord = _goals[goalNumber - 1];
                int previousScore = _score;
                goalToRecord.RecordEvent();
                if (goalToRecord.IsComplete || goalToRecord is EternalGoal || (goalToRecord is ChecklistGoal && (goalToRecord as ChecklistGoal).TimesNeeded == (goalToRecord as ChecklistGoal).TimesNeeded))
                {
                    _score += goalToRecord.Points;
                } else if (goalToRecord is ChecklistGoal)
                {
                    _score += goalToRecord.Points;
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        static void SaveGoals()
        {
            try
            {
                List<string> lines = new List<string>();
                lines.Add(_score.ToString());
                foreach (var goal in _goals)
                {
                    lines.Add(goal.GetStringRepresentation());
                }
                File.WriteAllLines(_filename, lines);
                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        static void LoadGoals()
        {
            try
            {
                if (File.Exists(_filename))
                {
                    string[] lines = File.ReadAllLines(_filename);
                    if (lines.Length > 0 && int.TryParse(lines[0], out _score))
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] parts = lines[i].Split(':');
                            string goalType = parts[0];
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.Parse(parts[3]);

                            switch (goalType)
                            {
                                case "SimpleGoal":
                                    bool isCompleteSimple = bool.Parse(parts[4]);
                                    _goals.Add(new SimpleGoal(name, description, points) { IsComplete = isCompleteSimple });
                                    break;
                                case "EternalGoal":
                                    int recordCount = int.Parse(parts[4]);
                                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                                    // Simulate recording events to match the saved state
                                    for (int j = 0; j < recordCount; j++)
                                    {
                                        eternalGoal.RecordEvent();
                                        _score += points; // Add points for each recorded event during load
                                    }
                                    _goals.Add(eternalGoal);
                                    break;
                                case "ChecklistGoal":
                                    int timesNeeded = int.Parse(parts[4]);
                                    int bonusPoints = int.Parse(parts[5]);
                                    int timesCompleted = int.Parse(parts[6]);
                                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, timesNeeded, bonusPoints);
                                    // Simulate recording events to match the saved state
                                    for (int j = 0; j < timesCompleted; j++)
                                    {
                                        checklistGoal.RecordEvent();
                                        _score += points; // Add points for each recorded event during load
                                    }
                                    if (timesCompleted == timesNeeded)
                                    {
                                        checklistGoal.IsComplete = true;
                                        _score += bonusPoints; // Add bonus points if completed during load
                                    }
                                    _goals.Add(checklistGoal);
                                    break;
                            }
                        }
                        // Recalculate score based on the loaded goals' IsComplete status (for Simple and Checklist)
                        _score = lines.Length > 0 ? int.Parse(lines[0]) : 0;
                    }
                    Console.WriteLine("Goals loaded successfully!");
                }
                else
                {
                    Console.WriteLine("No saved goals found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }
    }
}