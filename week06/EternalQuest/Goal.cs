using System;

abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A goal name is required.", nameof(name));
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("A goal description is required.", nameof(description));
        }
        if (points <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points must be greater than zero.");
        }

        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public abstract bool IsComplete { get; }

    public abstract int RecordEvent();
    protected abstract string Type { get; }
    protected abstract void WriteProgress(GoalData data);

    public string GetStatus()
    {
        string completionMark = IsComplete ? "[X]" : "[ ]";
        return $"{completionMark} {_name} ({_description}) {GetProgressDescription()}";
    }

    protected virtual string GetProgressDescription()
    {
        return $"- {_points} points";
    }

    public GoalData ToData()
    {
        GoalData data = new GoalData
        {
            Type = Type,
            Name = _name,
            Description = _description,
            Points = _points
        };
        WriteProgress(data);
        return data;
    }

    public static Goal FromData(GoalData data)
    {
        if (data is null || string.IsNullOrWhiteSpace(data.Type))
        {
            throw new InvalidDataException("A saved goal is missing its type.");
        }

        return data.Type switch
        {
            "Simple" => new SimpleGoal(data.Name, data.Description, data.Points, data.IsComplete),
            "Eternal" => new EternalGoal(data.Name, data.Description, data.Points, data.TimesRecorded),
            "Checklist" => new ChecklistGoal(
                data.Name,
                data.Description,
                data.Points,
                data.TargetCount,
                data.BonusPoints,
                data.TimesRecorded),
            _ => throw new InvalidDataException($"Unknown saved goal type '{data.Type}'.")
        };
    }
}

sealed class GoalData
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
    public int TimesRecorded { get; set; }
    public int TargetCount { get; set; }
    public int BonusPoints { get; set; }
}
