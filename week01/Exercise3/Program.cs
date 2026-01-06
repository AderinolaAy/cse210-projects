using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random random = new Random();
        string playAgain;

        do
        {
            int magicNumber = random.Next(1, 101); // Random number between 1 and 100
            int guess;
            int guessCount = 0;

            Console.WriteLine("I've picked a magic number between 1 and 100. Try to guess it!");

            do
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                
                // Validate input
                while (!int.TryParse(input, out guess))
                {
                    Console.Write("Invalid input. Please enter a number: ");
                    input = Console.ReadLine();
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher!");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower!");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the magic number in {guessCount} tries.");
                }

            } while (guess != magicNumber);

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing! Goodbye.");
        
    }
}