using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 1000);
        Console.WriteLine("Try and guess the magic number between 1 and 1000.");
        Console.Write("What is your guess?" ); 
        string userInput = Console.ReadLine();
        int userGuess = int.Parse(userInput);
        while (userGuess != magicNumber)
        {
            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            Console.Write("What is your guess? ");
            userInput = Console.ReadLine();
            userGuess = int.Parse(userInput);
        }
        Console.WriteLine("Congratulations! You guessed the magic number.");
    }
}