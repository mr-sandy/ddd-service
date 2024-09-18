namespace Domain.Activities;

public abstract class Activity(string who, DateTime when)
{
    public string Who { get; } = who;

    public DateTime When { get; } = when;
}
