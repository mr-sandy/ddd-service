namespace Domain.Activities;

public class AddOrderLineActivity(string who, DateTime when, string productCode, int quantity) : Activity(who, when)
{
    public string ProductCode { get; } = productCode;

    public int Quantity { get; } = quantity;
}
