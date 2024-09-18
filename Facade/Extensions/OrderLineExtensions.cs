using Domain;
using Facade.Resources;

namespace Facade.Extensions;

public static class OrderLineExtensions
{
    public static IEnumerable<OrderLineResource> ToResource(this IEnumerable<OrderLine> orderLines)
    {
        return orderLines.Select(ol => ol.ToResource()) ?? [];
    }

    public static OrderLineResource ToResource(this OrderLine orderLine)
    {
        return new OrderLineResource()
        {
            Id = orderLine.Id,
            ProductNumber = orderLine.ProductCode,
            Quantity = orderLine.Quantity
        };
    }

}
