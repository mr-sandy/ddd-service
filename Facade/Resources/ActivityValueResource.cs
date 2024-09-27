namespace Facade.Resources;

public class ActivityValueResource
{
    public ActivityValueResource(string field, string value)
    {
        this.Field = field;
        this.Value = value;
    }

    public string Field { get; }

    public string Value { get; }
}