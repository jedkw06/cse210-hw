using System;
using System.Collections.Generic;

// Exceeds the base requirement by using a small library of scriptures and choosing one at random
// for each run, which helps the user practice multiple passages instead of only one memorization exercise.
public class Program
{
    public static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son."),
            new Scripture(
                new Reference("Alma", 32, 21),
                "If ye have faith ye hope for things which are not seen which are true.")
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a few words or type 'quit' to exit.");
            string input = Console.ReadLine() ?? string.Empty;

            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                scripture.Display();
                break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("You finished memorizing the scripture.");
    }
}