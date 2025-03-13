// Changed the SaveToFile and LoadFromFile methods to use JSON.
// Made the Entry class properties settable and added an empty constructor to allow JSON deserialization,
// such as invalid JSON format or file not found errors. 
// Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; // Added for JSON serialization

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nJournal Application");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file (JSON)"); // Modified to use JSON
                Console.WriteLine("4. Load the journal from a file (JSON)"); // Modified to use JSON
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.WriteNewEntry();
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        Console.Write("Enter filename to save (JSON): ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToJsonFile(saveFilename); // Modified to use JSON
                        break;
                    case "4":
                        Console.Write("Enter filename to load (JSON): ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromJsonFile(loadFilename); // Modified to use JSON
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }

    // Journal.cs
    public class Journal
    {
        private List<Entry> entries = new List<Entry>();
        private List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What are three things I'm grateful for today?",
            "What did I learn today?",
            "What was a challenge I faced and how did I overcome it?",
            "What act of kindness did I perform or witness today?",
            "What made me laugh today?"
        };

        public void WriteNewEntry()
        {
            Random random = new Random();
            int promptIndex = random.Next(prompts.Count);
            string prompt = prompts[promptIndex];

            Console.WriteLine(prompt);
            string response = Console.ReadLine();

            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entries.Add(new Entry(prompt, response, date));
            Console.WriteLine("Entry added.");
        }

        public void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Journal is empty.");
                return;
            }

            foreach (Entry entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine("---");
            }
        }

        // Modified to save to JSON
        public void SaveToJsonFile(string filename)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(entries);
                File.WriteAllText(filename, jsonString);
                Console.WriteLine("Journal saved to JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal to JSON: {ex.Message}");
            }
        }

        // Modified to load from JSON
        public void LoadFromJsonFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    string jsonString = File.ReadAllText(filename);
                    entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
                    Console.WriteLine("Journal loaded from JSON.");
                } else
                {
                    Console.WriteLine("File not found.");
                }

            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON format in file.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal from JSON: {ex.Message}");
            }
        }
    }

    // Entry.cs
    public class Entry
    {
        public string Prompt { get; set; } // Make properties settable for JSON serialization
        public string Response { get; set; }
        public string Date { get; set; }

        public Entry() { } // Required for JSON deserialization

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }
    }
}