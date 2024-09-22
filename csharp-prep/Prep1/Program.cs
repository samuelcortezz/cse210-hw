using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask the last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Show the result
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
