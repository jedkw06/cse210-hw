using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

sealed class Quest
{
    private const int PointsPerLevel = 500;
    private static readonly string[] LevelTitles =
    {
        "Novice Adventurer",
        "Scripture Scout",
        "Courageous Pioneer",
        "Temple Guardian",
        "Level 13 Ninja Unicorn",
        "Celestial Champion"
    };

    private readonly List<Goal> _goals;

    public Quest()
        : this(0, new List<Goal>())
    {
    }

    private Quest(long score, List<Goal> goals)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(score));
        }
        Score = score;
        _goals = goals;
    }

    public long Score { get; private set; }
    public IReadOnlyList<Goal> Goals => _goals;
    public long Level => Score / PointsPerLevel + 1;
    public string LevelTitle => LevelTitles[(int)((Level - 1) % LevelTitles.Length)];
    public int PointsUntilNextLevel => PointsPerLevel - (int)(Score % PointsPerLevel);

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal ?? throw new ArgumentNullException(nameof(goal)));
    }

    public RecordResult RecordGoal(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(goalIndex));
        }

        long previousLevel = Level;
        int pointsAwarded = _goals[goalIndex].RecordEvent();
        Score = checked(Score + pointsAwarded);
        return new RecordResult(pointsAwarded, Level > previousLevel, Level, LevelTitle);
    }

    public void Save(string path)
    {
        QuestData data = new QuestData
        {
            Score = Score,
            Goals = _goals.Select(goal => goal.ToData()).ToList()
        };
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public static Quest Load(string path)
    {
        string json = File.ReadAllText(path);
        QuestData data = JsonSerializer.Deserialize<QuestData>(json);
        if (data is null || data.Score < 0 || data.Goals is null)
        {
            throw new InvalidDataException("The save file does not contain valid quest data.");
        }

        List<Goal> goals = data.Goals.Select(Goal.FromData).ToList();
        return new Quest(data.Score, goals);
    }
}

sealed class QuestData
{
    public long Score { get; set; }
    public List<GoalData> Goals { get; set; }
}

readonly record struct RecordResult(int PointsAwarded, bool LevelUp, long Level, string LevelTitle);
