namespace Facade.Resources;

public class CreateOrderLineResource
{
    public required string ProductNumber { get; set; }

    public required int Quantity { get; set; }
}
