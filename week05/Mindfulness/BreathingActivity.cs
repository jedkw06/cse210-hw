using System;
using System.Diagnostics;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void ExecuteActivity()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        bool breatheIn = true;

        while (GetRemainingSeconds(stopwatch, Duration) > 0)
        {
            Console.WriteLine(breatheIn ? "Breathe in..." : "Breathe out...");
            int seconds = Math.Min(4, GetRemainingSeconds(stopwatch, Duration));
            Pause(seconds);
            breatheIn = !breatheIn;
        }
    }
}