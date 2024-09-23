using System;

class Program
{
    static void Main()
    {
        // Step 3: Call functions in Main and pass data between them

        DisplayWelcome();  // Call to display welcome message
        string userName = PromptUserName();  // Get the user's name
        int favoriteNumber = PromptUserNumber();  // Get the user's favorite number
        int squaredNumber = SquareNumber(favoriteNumber);  // Square the favorite number
        DisplayResult(userName, squaredNumber);  // Display the result
    }

    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt the user's name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to prompt the user's favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function to calculate the square of a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result with the user's name and the squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
