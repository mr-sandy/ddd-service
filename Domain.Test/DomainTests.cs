namespace Domain.Test;

using Domain;
using Domain.Activities;

[TestClass]
public class DomainTests
{

    [TestMethod]
    public void WhenAddingAnOrderLine()
    {
        // Arrange
        var order = new Order(new CreateOrderActivity("sandy", new DateTime(2024, 09, 17, 19, 15, 0, DateTimeKind.Utc), 100));
        var activity = new AddOrderLineActivity("sandy", new DateTime(2024, 09, 17, 19, 15, 0, DateTimeKind.Utc), "Product A", 1);

        // Act
        order.AddOrderLine(activity);

        // Assert
        Assert.AreEqual(order.Activities.Count(), 2);
        Assert.AreEqual(order.OrderLines.Count(), 1);
        Assert.AreEqual(order.CustomerId, 100);
        Assert.AreEqual(order.OrderLines.FirstOrDefault()?.ProductCode, "Product A");
        Assert.AreEqual(order.OrderLines.FirstOrDefault()?.Quantity, 1);
        Assert.IsInstanceOfType<CreateOrderActivity>(order.Activities.FirstOrDefault());
        Assert.IsInstanceOfType<AddOrderLineActivity>(order.Activities.ElementAt(1));
    }
}