using Domain;
using Facade.Resources;

namespace Facade.Extensions;

public static class OrderExtensions
{
    public static OrderResource ToResource(this Order order)
    {
        return new OrderResource()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderLines = order.OrderLines.ToResource()
        };
    }

}
