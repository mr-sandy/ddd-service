using System.Runtime.CompilerServices;
using Domain.Activities;

namespace Domain;

public class Order
{
    private readonly List<Activity> activities = [];

    private readonly List<OrderLine> orderLines = [];

    public Order(CreateOrderActivity activity)
    {
        this.activities.Add(activity);

        this.CustomerId = activity.CustomerId;
    }

    public int Id { get; set; }

    public int CustomerId { get; private set; }

    public IEnumerable<Activity> Activities => this.activities;

    public IEnumerable<OrderLine> OrderLines => this.orderLines;

    public OrderLine AddOrderLine(AddOrderLineActivity activity)
    {
        int id = this.orderLines.Any() ? this.orderLines.Max(ol => ol.Id) + 1 : 1;
        
        var orderLine = new OrderLine(id, activity.ProductCode, activity.Quantity);

        this.orderLines.Add(orderLine);

        this.activities.Add(activity);

        return orderLine;
    }

    public OrderLine? RemoveOrderLine(RemoveOrderLineActivity activity)
    {
        var orderLine = this.orderLines.Find(ol => ol.Id == activity.OrderLineId);

        if (orderLine == null)
        {
            return null;
        }

        this.orderLines.Remove(orderLine);

        this.activities.Add(activity);

        return orderLine;
    }
}
