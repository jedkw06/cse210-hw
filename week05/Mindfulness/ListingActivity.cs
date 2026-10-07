using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private readonly Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void ExecuteActivity()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        List<string> items = new List<string>();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {Prompts[_random.Next(Prompts.Length)]} ---");
        Console.WriteLine();
        Console.WriteLine("You may begin in...");
        PauseForRemainingTime(stopwatch, Duration, 5);

        if (GetRemainingSeconds(stopwatch, Duration) > 0)
        {
            Console.Write(">");
        }

        while (GetRemainingSeconds(stopwatch, Duration) > 0)
        {
            string item = ReadItemUntilEnterOrTimeRunsOut(stopwatch, Duration);
            if (item is null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item.Trim());
                Console.WriteLine($"\n{items.Count} items listed.");
                if (GetRemainingSeconds(stopwatch, Duration) > 0)
                {
                    Console.Write(">");
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} item(s).");
    }

    private static string ReadItemUntilEnterOrTimeRunsOut(Stopwatch stopwatch, int duration)
    {
        if (Console.IsInputRedirected)
        {
            string redirectedItem = Console.ReadLine();
            return GetRemainingSeconds(stopwatch, duration) > 0 ? redirectedItem : null;
        }

        List<char> characters = new List<char>();

        while (GetRemainingSeconds(stopwatch, duration) > 0)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                {
                    return new string(characters.ToArray());
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (characters.Count > 0)
                    {
                        characters.RemoveAt(characters.Count - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    characters.Add(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }

            Thread.Sleep(50);
        }

        return null;
    }
}