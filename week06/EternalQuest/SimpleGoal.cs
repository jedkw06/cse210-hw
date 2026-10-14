using System;

sealed class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : this(name, description, points, false)
    {
    }

    internal SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete => _isComplete;
    protected override string Type => "Simple";

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    protected override void WriteProgress(GoalData data)
    {
        data.IsComplete = _isComplete;
    }
}
