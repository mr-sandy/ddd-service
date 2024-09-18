namespace Facade.Resources;

public class OrderResource
{
    public required int Id { get; set; }

    public required int CustomerId { get; set; }

    public required IEnumerable<OrderLineResource> OrderLines { get; set; }
}
