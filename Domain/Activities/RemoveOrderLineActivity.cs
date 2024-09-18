namespace Domain.Activities
{
    public class RemoveOrderLineActivity(string who, DateTime when, int orderLineId) : Activity(who, when)
    {
        public int OrderLineId { get; } = orderLineId;
    }
}