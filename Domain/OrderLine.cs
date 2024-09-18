namespace Domain;

public class OrderLine(int id, string productCode, int quantity)
{
    public int Id { get; } = id;

    public string ProductCode { get; } = productCode;

    public int Quantity { get; } = quantity;
}
