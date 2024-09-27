using Domain.Activities;
using Facade.Resources;

namespace Facade.Extensions;

public class ResourceBuildingActivityVisitor : IActivityVisitor<ActivityResource>
{
    public ActivityResource Visit(CreateOrderActivity activity)
    {
        return new ActivityResource
        {
            Who = activity.Who,
            When = activity.When,
            Type = "Create Order",
            Values = [
                new ActivityValueResource("CustomerId", activity.CustomerId.ToString())
        ]
        };
    }

    public ActivityResource Visit(AddOrderLineActivity activity)
    {
        return new ActivityResource
        {
            Who = activity.Who,
            When = activity.When,
            Type = "Add Order Line",
            Values = [
               new ActivityValueResource("ProductCode", activity.ProductCode.ToString()),
                new ActivityValueResource("Quantity", activity.Quantity.ToString())
            ]
        };
    }

    public ActivityResource Visit(RemoveOrderLineActivity activity)
    {
        return new ActivityResource
        {
            Who = activity.Who,
            When = activity.When,
            Type = "Remove Order Line",
            Values = [
                new ActivityValueResource("OrderLineId", activity.OrderLineId.ToString())
            ]
        };
    }
}


