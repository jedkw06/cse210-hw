using System;

sealed class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points)
        : this(name, description, points, 0)
    {
    }

    internal EternalGoal(string name, string description, int points, int timesRecorded)
        : base(name, description, points)
    {
        if (timesRecorded < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(timesRecorded));
        }
        _timesRecorded = timesRecorded;
    }

    public override bool IsComplete => false;
    protected override string Type => "Eternal";

    public override int RecordEvent()
    {
        _timesRecorded = checked(_timesRecorded + 1);
        return Points;
    }

    protected override string GetProgressDescription()
    {
        return $"- recorded {_timesRecorded} times, {Points} points each time";
    }

    protected override void WriteProgress(GoalData data)
    {
        data.TimesRecorded = _timesRecorded;
    }
}
