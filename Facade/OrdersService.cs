using Domain;
using Domain.Activities;
using Domain.Repositories;
using Facade.Extensions;
using Facade.Resources;
using Facade.Results;

namespace Facade;

public class OrdersService(IOrderRepository orderRepository)
{
    private readonly IOrderRepository orderRepository = orderRepository;

    public IFacadeResult<OrderResource> CreateOrder(CreateOrderResource resource, string userId)
    {
        var activity = new CreateOrderActivity(userId, DateTime.UtcNow, resource.CustomerId);

        var order = new Order(activity);

        this.orderRepository.Add(order);

        return new CreatedFacadeResult<OrderResource>(order.ToResource());
    }

    public IFacadeResult<OrderLineResource> AddOrderLine(int orderId, OrderLineResource resource, string userId)
    {
        var order = this.orderRepository.Get(orderId);

        if (order == null)
        {
            return new NotFoundFacadeResult<OrderLineResource>();
        }

        var activity = new AddOrderLineActivity(userId, DateTime.UtcNow, resource.ProductNumber, resource.Quantity);

        var orderLine = order.AddOrderLine(activity);

        return new CreatedFacadeResult<OrderLineResource>(orderLine.ToResource());
    }

    public IFacadeResult<OrderLineResource> RemoveOrderLine(int orderId, int orderLineId, string userId)
    {
        var order = this.orderRepository.Get(orderId);

        if (order == null)
        {
            return new NotFoundFacadeResult<OrderLineResource>();
        }

        var activity = new RemoveOrderLineActivity(userId, DateTime.UtcNow, orderLineId);

        var orderLine = order.RemoveOrderLine(activity);

        if (orderLine == null)
        {
            return new NotFoundFacadeResult<OrderLineResource>();
        }

        return new CreatedFacadeResult<OrderLineResource>(orderLine.ToResource());
    }

    public IFacadeResult<OrderResource> GetOrder(int orderId)
    {
        var order = this.orderRepository.Get(orderId);

        if (order == null)
        {
            return new NotFoundFacadeResult<OrderResource>();
        }

        return new SuccessFacadeResult<OrderResource>(order.ToResource());
    }

    public IFacadeResult<IEnumerable<ActivityResource>> GetOrderActivities(int orderId)
    {
        var order = this.orderRepository.Get(orderId);

        if (order == null)
        {
            return new NotFoundFacadeResult<IEnumerable<ActivityResource>>();
        }

        return new SuccessFacadeResult<IEnumerable<ActivityResource>>(order.Activities.ToResource());
    }
}
