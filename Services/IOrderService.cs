using DTOs;
using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<OrderMoreInfoDTO> getOrderById(int id);
        Task<OrderDTO> AddOrder(CreatOrderDTO createOrder);
    }
}