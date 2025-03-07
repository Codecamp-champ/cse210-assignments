using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101); // Generates a random number between 1 and 100
            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("I am thinking of a number between 1 and 100. Try to guess it!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    guessCount++;

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
                        //Stretch challenge
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine($"It took you {guessCount} guesses.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();
            playAgain = playAgainInput == "yes";
        }

        Console.WriteLine("Thanks for playing!");
    }
}