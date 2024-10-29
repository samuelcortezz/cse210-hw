using System;
using System.Collections.Generic;

public class Activity
{
    private DateTime date;
    protected int duration; // Changed to protected

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    public string GetSummary()
    {
        return $"{date:dd MMM yyyy} {GetType().Name} ({duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}

public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / duration) * 60;

    public override double GetPace() => duration / distance;
}

public class Cycling : Activity
{
    private double speed; // in miles per hour

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * duration) / 60;

    public override double GetSpeed() => speed;

    public override double GetPace() => 60 / speed;
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance() => (laps * 50) / 1000.0 * 0.62; // Convert to miles

    public override double GetSpeed() => (GetDistance() / duration) * 60;

    public override double GetPace() => duration / GetDistance();
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create instances of each activity type
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 4), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 5), 30, 20));

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
