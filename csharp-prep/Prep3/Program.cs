using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            // Generar un número aleatorio entre 1 y 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            // Inicializar la variable de intento y el contador de intentos
            int guess = -1;
            int guessCount = 0;

            // Bucle que sigue hasta que el usuario acierte
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;  // Incrementar el contador de intentos

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} attempts!");
                }
            }

            // Preguntar si quiere jugar otra vez
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower();
        }
    }
}
