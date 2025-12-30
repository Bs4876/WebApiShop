using AutoMapper;
using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

        public async Task<OrderMoreInfoDTO> getOrderById(int id)
        {
            OrdersTbl orderTbl = await _iOrserRepository.getOrderById(id);
            OrderMoreInfoDTO OrderDTos = _mapper.Map<OrdersTbl, OrderMoreInfoDTO>(orderTbl);
            return OrderDTos;      
        }
        public async Task<OrderDTO> AddOrder(CreatOrderDTO createOrder)
        {
            OrdersTbl order = _mapper.Map<CreatOrderDTO, OrdersTbl>(createOrder);
            double sum = 0;
            foreach (var item in createOrder.OrderItemDTOs)
            {
                sum += (item.productPrice*item.Quantity);
            }
            order.OrderSum=sum;
            OrdersTbl orderTbl = await _iOrserRepository.AddOrder(order);
            OrderDTO OrderDTOs = _mapper.Map<OrdersTbl, OrderDTO>(orderTbl);

            return OrderDTOs;
        }
    }
}
//dotnet restore