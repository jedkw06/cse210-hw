using System;

sealed class ChecklistGoal : Goal
{
    private readonly int _targetCount;
    private readonly int _bonusPoints;
    private int _timesRecorded;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : this(name, description, points, targetCount, bonusPoints, 0)
    {
    }

    internal ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int timesRecorded)
        : base(name, description, points)
    {
        if (targetCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(targetCount), "The target must be greater than zero.");
        }
        if (bonusPoints < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonusPoints), "The bonus cannot be negative.");
        }
        if (timesRecorded < 0 || timesRecorded > targetCount)
        {
            throw new ArgumentOutOfRangeException(nameof(timesRecorded), "Progress must be between zero and the target.");
        }

        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _timesRecorded = timesRecorded;
    }

    public override bool IsComplete => _timesRecorded >= _targetCount;
    protected override string Type => "Checklist";

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _timesRecorded++;
        return _timesRecorded == _targetCount
            ? checked(Points + _bonusPoints)
            : Points;
    }

    protected override string GetProgressDescription()
    {
        string status = $"Completed {_timesRecorded}/{_targetCount} times - {Points} points each time";
        return IsComplete ? $"{status}; bonus earned: {_bonusPoints} points" : $"{status}; bonus: {_bonusPoints} points";
    }

    protected override void WriteProgress(GoalData data)
    {
        data.TimesRecorded = _timesRecorded;
        data.TargetCount = _targetCount;
        data.BonusPoints = _bonusPoints;
    }
}
