namespace Domain;

public class OrderLine(string productCode, int quantity)
{
    public string ProductCode { get; } = productCode;

    public int Quantity { get; } = quantity;
}
