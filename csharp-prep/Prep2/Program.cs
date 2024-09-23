using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicita el porcentaje de la calificación
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter = "";  // La variable para almacenar la letra de la calificación

        // Determina la letra de la calificación
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Mostrar la letra de la calificación
        Console.WriteLine($"Your grade is: {letter}");

        // Determinar si el estudiante pasó el curso
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying, you can do better next time.");
        }
    }
}
