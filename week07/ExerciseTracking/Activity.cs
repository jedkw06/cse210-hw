using System.Globalization;

public abstract class Activity
{
    private readonly DateTime _date;
    private readonly int _length;

    protected Activity(DateTime date, int length)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "Activity length must be greater than zero.");
        }

        _date = date;
        _length = length;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLength()
    {
        return _length;
    }

    public abstract string GetActivityType();
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0} {1} ({2} min): Distance {3:0.0} miles, Speed: {4:0.0} mph, Pace: {5:0.0} min per mile",
            _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture),
            GetActivityType(),
            _length,
            GetDistance(),
            GetSpeed(),
            GetPace());
    }
}
