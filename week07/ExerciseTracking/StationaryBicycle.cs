public class StationaryBicycle : Activity
{
    private readonly double _speed;

    public StationaryBicycle(DateTime date, int length, double speed) : base(date, length)
    {
        if (speed <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speed), "Speed must be greater than zero.");
        }

        _speed = speed;
    }

    public override string GetActivityType()
    {
        return "Stationary Bicycle";
    }

    public override double GetDistance()
    {
        return _speed * GetLength() / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return GetLength() / GetDistance();
    }
}
