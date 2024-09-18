namespace Facade.Resources;

public class OrderResource : CreateOrderResource
{
    public required int Id { get; set; }

    public required IEnumerable<OrderLineResource> OrderLines { get; set; }
}
