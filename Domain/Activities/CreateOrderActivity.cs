namespace Domain.Activities;

public class CreateOrderActivity(string who, DateTime when, int customerId) : Activity(who, when)
{
    public int CustomerId { get; } = customerId;
}
