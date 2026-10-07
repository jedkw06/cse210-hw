using System;
using System.Diagnostics;
using System.Threading;

abstract class MindfulnessActivity
{
    private readonly string _name;
    private readonly string _description;
    private int _duration;

    protected MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int Duration => _duration;

    public void Run()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = ReadDuration();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        Pause(3);
        ExecuteActivity();

        Console.WriteLine();
        Console.WriteLine("Good job!");
        Pause(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        Pause(3);
    }

    protected abstract void ExecuteActivity();

    protected static int GetRemainingSeconds(Stopwatch stopwatch, int duration)
    {
        return Math.Max(0, duration - (int)stopwatch.Elapsed.TotalSeconds);
    }

    protected static void PauseForRemainingTime(Stopwatch stopwatch, int duration, int maximumSeconds)
    {
        int seconds = Math.Min(maximumSeconds, GetRemainingSeconds(stopwatch, duration));
        if (seconds > 0)
        {
            Pause(seconds);
        }
    }

    public static void Pause(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        for (int remaining = seconds; remaining > 0; remaining--)
        {
            Console.Write($"{remaining} ");
            for (int frame = 0; frame < 4; frame++)
            {
                Console.Write($"\b{spinner[frame]}");
                Thread.Sleep(250);
            }
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    private static int ReadDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Please enter a whole number of seconds greater than zero.");
        }
    }
}