using Domain.Activities;
using Facade.Resources;

namespace Facade.Extensions;

public static class ActivityExtensions
{
    public static IEnumerable<ActivityResource> ToResource(this IEnumerable<Activity> activities)
    {
        var visitor = new ResourceBuildingActivityVisitor();

        return activities.Select(a => a.Accept(visitor)) ?? [];
    }
}


