using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<OrdersTbl> getOrderById(int id);
        Task<OrdersTbl> invite(OrdersTbl order);
    }
}