using System;
using System.Collections.Generic;
using System.Threading;

class MindfulnessProgram
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Start();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Start();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Start();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}

class Activity
{
    protected int duration;
    protected string description;

    public virtual void Start()
    {
        Console.WriteLine(description);
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Prepare();
        PerformActivity();
        End();
    }

    protected void Prepare()
    {
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);
    }

    protected void End()
    {
        Console.WriteLine($"Good job! You've completed the activity for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected virtual void PerformActivity() { }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        description = "This activity will help you relax by guiding you through breathing in and out slowly. Focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        for (int i = 0; i < duration; i += 6)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"{i}...");
            Thread.Sleep(1000);
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?"
    };

    public ReflectionActivity()
    {
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(3);

        for (int i = 0; i < duration; i += 10)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(3);
        }
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity()
    {
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(3);

        List<string> items = new List<string>();
        Console.WriteLine("Start listing items:");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items.");
    }
}
