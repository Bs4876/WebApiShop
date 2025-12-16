using AutoMapper;
using DTOs;
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
        IMapper _mapper;
        public OrderService(IOrderRepository _iOrserRepository, IMapper mapper)
        {
            this._iOrserRepository = _iOrserRepository;
            this._mapper = mapper;
        }

        public async Task<MoreInfoOrderDTO> getOrderById(int id)
        {
            OrdersTbl orderTbl = await _iOrserRepository.getOrderById(id);
            MoreInfoOrderDTO  OrderDTos = _mapper.Map<OrdersTbl,MoreInfoOrderDTO>(orderTbl);
            return OrderDTos;      
        }
        public async Task<LessInfoOrderDTO> AddOrder(OrdersTbl order)
        {
            OrdersTbl orderTbl = await _iOrserRepository.AddOrder(order);
            LessInfoOrderDTO OrderDTOs = _mapper.Map<OrdersTbl,LessInfoOrderDTO>(orderTbl);
            return OrderDTOs;
        }
    }
}
