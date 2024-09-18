using Domain;
using Domain.Repositories;

namespace Persistence;

public class OrderRepository : IOrderRepository
{
    private static List<Order> orders = [];

    public void Add(Order order)
    {
        orders.Add(order);

        order.Id = orders.Count();
    }

    public Order? Get(int id)
    {
        return orders.Find(o => o.Id == id) ?? null;
    }
}
