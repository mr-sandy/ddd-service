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
        this.activities.Add(activity);

        var orderLine = new OrderLine(activity.ProductCode, activity.Quantity);

        this.orderLines.Add(orderLine);

        return orderLine;
    }
}
