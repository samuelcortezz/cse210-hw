using System;
using System.Collections.Generic;

// The main class that handles the user interface and manages the flow of the Journal Program.
public class Program
{
    // A list of random prompts that the program will use when creating new journal entries.
    private static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool quit = false;

        // Display a menu until the user chooses to quit.
        while (!quit)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option (1-5): ");
            string option = Console.ReadLine();

            // Handle each menu option based on the user's choice.
            switch (option)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a number between 1 and 5.");
                    break;
            }
        }
    }

    private static void WriteNewEntry(Journal journal)
    {
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {randomPrompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();
        journal.AddEntry(new Entry(date, randomPrompt, response));
    }

    private static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine($"Journal saved to {filename}");
    }

    // Prompts the user for a filename and saves the current journal entries to the file.
    private static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine($"Journal loaded from {filename}");
    }
}
