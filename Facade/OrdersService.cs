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

        return new CreatedResult<OrderResource>(order.ToResource());
    }

    public IFacadeResult<OrderLineResource> AddOrderLine(int orderId, OrderLineResource resource, string userId)
    {
        var order = this.orderRepository.Get(orderId);

        if (order == null)
        {
            return new NotFoundResult<OrderLineResource>();
        }

        var activity = new AddOrderLineActivity(userId, DateTime.UtcNow, resource.ProductNumber, resource.Quantity);

        var orderLine = order.AddOrderLine(activity);

        return new SuccessResult<OrderLineResource>(orderLine.ToResource());
    }

    public IFacadeResult<OrderResource> GetOrder(int orderId)
    {
        var order = this.orderRepository.Get(orderId);

        if (order == null)
        {
            return new NotFoundResult<OrderResource>();
        }

        return new SuccessResult<OrderResource>(order.ToResource());
    }
}
