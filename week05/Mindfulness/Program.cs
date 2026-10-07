1using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine();
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            if (choice is null)
            {
                keepRunning = false;
                continue;
            }

            MindfulnessActivity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (choice == "4")
            {
                keepRunning = false;
            }
            else if (activity is null)
            {
                Console.WriteLine("Please enter a number from 1 to 4.");
                MindfulnessActivity.Pause(2);
            }
            else
            {
                activity.Run();
            }
        }

        Console.WriteLine("Thank you for practicing mindfulness. Goodbye!");
    }
}
