using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Base class
    abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool IsCompleted { get; set; }

        public Goal(string name, int points)
        {
            Name = name;
            Points = points;
            IsCompleted = false;
        }

        public abstract void RecordProgress();
        public abstract string GetStringRepresentation();
        public abstract void DisplayProgress();
    }

    // SimpleGoal class
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override void RecordProgress()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
            }
            else
            {
                Console.WriteLine($"The goal '{Name}' has already been completed.");
            }
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{Name},{Points},{IsCompleted}";
        }

        public override void DisplayProgress()
        {
            string status = IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {Name} - {Points} points");
        }
    }

    // EternalGoal class
    class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override void RecordProgress()
        {
            Console.WriteLine($"Progress recorded for '{Name}' - You earned {Points} points.");
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{Name},{Points}";
        }

        public override void DisplayProgress()
        {
            Console.WriteLine($"[∞] {Name} - {Points} points per entry");
        }
    }

    // ChecklistGoal class
    class ChecklistGoal : Goal
    {
        public int TargetCompletion { get; set; }
        public int CurrentCompletion { get; set; }
        public int BonusPoints { get; set; }

        public ChecklistGoal(string name, int points, int targetCompletion, int bonusPoints)
            : base(name, points)
        {
            TargetCompletion = targetCompletion;
            CurrentCompletion = 0;
            BonusPoints = bonusPoints;
        }

        public override void RecordProgress()
        {
            if (CurrentCompletion < TargetCompletion)
            {
                CurrentCompletion++;
                Console.WriteLine($"Progress recorded for '{Name}' - {Points} points earned.");

                if (CurrentCompletion == TargetCompletion)
                {
                    IsCompleted = true;
                    Console.WriteLine($"Congratulations! You completed the goal '{Name}' and earned a bonus of {BonusPoints} points!");
                }
            }
            else
            {
                Console.WriteLine($"The goal '{Name}' has already been completed.");
            }
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{Name},{Points},{CurrentCompletion},{TargetCompletion},{BonusPoints}";
        }

        public override void DisplayProgress()
        {
            string status = IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {Name} - {Points} points per entry. Completed {CurrentCompletion}/{TargetCompletion} times.");
        }
    }

    // Program class
    class Program
    {
        private static List<Goal> goals = new List<Goal>();
        private static int totalPoints = 0;

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Eternal Quest ---");
                Console.WriteLine("1. Create a Goal");
                Console.WriteLine("2. Record Progress");
                Console.WriteLine("3. Display Goals");
                Console.WriteLine("4. Save Progress");
                Console.WriteLine("5. Load Progress");
                Console.WriteLine("6. Show Total Score");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        RecordGoalProgress();
                        break;
                    case "3":
                        DisplayGoals();
                        break;
                    case "4":
                        SaveProgress();
                        break;
                    case "5":
                        LoadProgress();
                        break;
                    case "6":
                        Console.WriteLine($"Total Score: {totalPoints}");
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CreateGoal()
        {
            Console.WriteLine("\nType of goal:");
            Console.WriteLine("1. Simple");
            Console.WriteLine("2. Eternal");
            Console.WriteLine("3. Checklist");
            Console.Write("Select the type: ");
            
            string type = Console.ReadLine();
            Console.Write("Goal Name: ");
            string name = Console.ReadLine();
            Console.Write("Points for completion: ");
            int points = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, points));
                    break;
                case "3":
                    Console.Write("Times required to complete: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus points upon completion: ");
                    int bonus = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }
        }

        static void RecordGoalProgress()
        {
            Console.WriteLine("\nSelect a goal:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                goals[i].DisplayProgress();
            }
            Console.Write("Option: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < goals.Count)
            {
                goals[index].RecordProgress();
                if (!goals[index].IsCompleted || goals[index] is EternalGoal)
                {
                    totalPoints += goals[index].Points;
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        static void DisplayGoals()
        {
            Console.WriteLine("\n--- Goal List ---");
            foreach (Goal goal in goals)
            {
                goal.DisplayProgress();
            }
        }

        static void SaveProgress()
        {
            using (StreamWriter file = new StreamWriter("progress.txt"))
            {
                file.WriteLine(totalPoints);
                foreach (Goal goal in goals)
                {
                    file.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Progress saved.");
        }

        static void LoadProgress()
        {
            if (File.Exists("progress.txt"))
            {
                string[] lines = File.ReadAllLines("progress.txt");
                totalPoints = int.Parse(lines[0]);
                goals.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(':');
                    string type = parts[0];
                    string[] details = parts[1].Split(',');

                    switch (type)
                    {
                        case "SimpleGoal":
                            goals.Add(new SimpleGoal(details[0], int.Parse(details[1])) { IsCompleted = bool.Parse(details[2]) });
                            break;
                        case "EternalGoal":
                            goals.Add(new EternalGoal(details[0], int.Parse(details[1])));
                            break;
                        case "ChecklistGoal":
                            goals.Add(new ChecklistGoal(details[0], int.Parse(details[1]), int.Parse(details[3]), int.Parse(details[4])) { CurrentCompletion = int.Parse(details[2]) });
                            break;
                    }
                }
                Console.WriteLine("Progress loaded.");
            }
            else
            {
                Console.WriteLine("No saved progress file found.");
            }
        }
    }
}
