using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _iOrserRepository;
        public OrderService(IOrderRepository _iOrserRepository)
        {
            this._iOrserRepository = _iOrserRepository;

        }

        public async Task<OrdersTbl> getOrderById(int id)
        {
            return await _iOrserRepository.getOrderById(id);
        }
        public async Task<OrdersTbl> invite(OrdersTbl order)
        {

            return await _iOrserRepository.invite(order);
        }
    }
}
