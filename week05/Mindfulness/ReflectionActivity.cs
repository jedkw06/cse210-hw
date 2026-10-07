using System;
using System.Diagnostics;

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions =
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private readonly Random _random = new Random();

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void ExecuteActivity()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {Prompts[_random.Next(Prompts.Length)]} ---");
        Console.WriteLine();
        Console.WriteLine("Reflect on this experience.");
        PauseForRemainingTime(stopwatch, Duration, 5);

        while (GetRemainingSeconds(stopwatch, Duration) > 0)
        {
            Console.WriteLine();
            Console.WriteLine(Questions[_random.Next(Questions.Length)]);
            PauseForRemainingTime(stopwatch, Duration, 5);
        }
    }
}