using System;

class Program
{
    // Creativity beyond the requirements: the quest awards a new level and a rotating
    // fantasy title for every 500 points, giving progress celebrations along the way.
    static void Main(string[] args)
    {
        Quest quest = new Quest();
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {quest.Score} points | Level {quest.Level}: {quest.LevelTitle}");
            Console.WriteLine();
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("1. Show score and level");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Create a new goal");
            Console.WriteLine("4. Record a goal event");
            Console.WriteLine("5. Save quest");
            Console.WriteLine("6. Load quest");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowScore(quest);
                    break;
                case "2":
                    ShowGoals(quest);
                    break;
                case "3":
                    CreateGoal(quest);
                    break;
                case "4":
                    RecordGoal(quest);
                    break;
                case "5":
                    SaveQuest(quest);
                    break;
                case "6":
                    quest = LoadQuest(quest);
                    break;
                case "7":
                case null:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Please choose an option from 1 to 7.");
                    break;
            }
        }

        Console.WriteLine("Keep going on your Eternal Quest!");
    }

    private static void ShowScore(Quest quest)
    {
        Console.WriteLine($"You have {quest.Score} points.");
        Console.WriteLine($"Level {quest.Level}: {quest.LevelTitle}");
        Console.WriteLine($"{quest.PointsUntilNextLevel} points until your next level.");
    }

    private static void ShowGoals(Quest quest)
    {
        if (quest.Goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }

        Console.WriteLine("Your goals:");
        for (int i = 0; i < quest.Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quest.Goals[i].GetStatus()}");
        }
    }

    private static void CreateGoal(Quest quest)
    {
        Console.WriteLine("Goal types:");
        Console.WriteLine("1. Simple goal (complete once)");
        Console.WriteLine("2. Eternal goal (repeat forever)");
        Console.WriteLine("3. Checklist goal (complete a set number of times)");
        string type = ReadChoice("Choose a goal type: ", "1", "2", "3");
        string name = ReadRequiredText("Goal name: ");
        string description = ReadRequiredText("Goal description: ");
        int points = ReadPositiveInteger("Points earned each time: ");

        Goal goal;
        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            default:
                int target = ReadPositiveInteger("How many completions are needed? ");
                int bonus = ReadNonNegativeInteger("Bonus points for reaching the target: ");
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
        }

        quest.AddGoal(goal);
        Console.WriteLine($"Added goal: {goal.Name}");
    }

    private static void RecordGoal(Quest quest)
    {
        if (quest.Goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording progress.");
            return;
        }

        ShowGoals(quest);
        int goalNumber = ReadInteger($"Which goal did you complete (1-{quest.Goals.Count})? ");
        if (goalNumber < 1 || goalNumber > quest.Goals.Count)
        {
            Console.WriteLine("That goal number is not in the list.");
            return;
        }

        RecordResult result = quest.RecordGoal(goalNumber - 1);
        if (result.PointsAwarded == 0)
        {
            Console.WriteLine("That goal is already complete; no points were awarded.");
            return;
        }

        Console.WriteLine($"Quest progress recorded! You earned {result.PointsAwarded} points.");
        if (result.LevelUp)
        {
            Console.WriteLine($"LEVEL UP! You reached level {result.Level}: {result.LevelTitle}!");
        }
        Console.WriteLine($"Your new score is {quest.Score} points.");
    }

    private static void SaveQuest(Quest quest)
    {
        string path = ReadPath("Save file name (default: eternal-quest.json): ");
        try
        {
            quest.Save(path);
            Console.WriteLine($"Quest saved to {path}.");
        }
        catch (Exception exception) when (
            exception is IOException ||
            exception is UnauthorizedAccessException ||
            exception is ArgumentException)
        {
            Console.WriteLine($"Could not save the quest: {exception.Message}");
        }
    }

    private static Quest LoadQuest(Quest currentQuest)
    {
        string path = ReadPath("Load file name (default: eternal-quest.json): ");
        try
        {
            Quest loadedQuest = Quest.Load(path);
            Console.WriteLine($"Quest loaded from {path}.");
            return loadedQuest;
        }
        catch (Exception exception) when (
            exception is IOException ||
            exception is UnauthorizedAccessException ||
            exception is ArgumentException ||
            exception is System.Text.Json.JsonException ||
            exception is InvalidDataException)
        {
            Console.WriteLine($"Could not load the quest: {exception.Message}");
            return currentQuest;
        }
    }

    private static string ReadChoice(string prompt, params string[] choices)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input is not null && Array.Exists(choices, choice => choice == input))
            {
                return input;
            }
            Console.WriteLine("Please choose one of the listed options.");
        }
    }

    private static string ReadRequiredText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Please enter a value.");
        }
    }

    private static int ReadPositiveInteger(string prompt)
    {
        while (true)
        {
            int value = ReadInteger(prompt);
            if (value > 0)
            {
                return value;
            }
            Console.WriteLine("Please enter a whole number greater than zero.");
        }
    }

    private static int ReadNonNegativeInteger(string prompt)
    {
        while (true)
        {
            int value = ReadInteger(prompt);
            if (value >= 0)
            {
                return value;
            }
            Console.WriteLine("Please enter zero or a positive whole number.");
        }
    }

    private static int ReadInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            Console.WriteLine("Please enter a whole number.");
        }
    }

    private static string ReadPath(string prompt)
    {
        Console.Write(prompt);
        string path = Console.ReadLine();
        return string.IsNullOrWhiteSpace(path) ? "eternal-quest.json" : path.Trim();
    }
}
