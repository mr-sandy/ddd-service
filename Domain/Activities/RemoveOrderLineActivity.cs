namespace Domain.Activities
{
    public class RemoveOrderLineActivity(string who, DateTime when, int orderLineId) : Activity(who, when)
    {
        public int OrderLineId { get; } = orderLineId;
    
    public override T Accept<T>(IActivityVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
}
}