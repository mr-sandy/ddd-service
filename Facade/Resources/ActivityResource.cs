namespace Facade.Resources;

public class ActivityResource
{
    public required string Who { get; set; }

    public required DateTime When { get; set; }

    public required string Type { get; set; }

    public IEnumerable<ActivityValueResource>? Values { get; set; }
}
