namespace Domain.Activities;

public interface IActivityVisitor<T>
{
    T Visit(CreateOrderActivity activity);

    T Visit(AddOrderLineActivity activity);

    T Visit(RemoveOrderLineActivity activity);
}