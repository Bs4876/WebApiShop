using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        ShopContext ShopContext_;
        public OrderRepository(ShopContext shopContext)
        {
            this.ShopContext_ = shopContext;
        }
        public async Task<OrdersTbl> getOrderById(int ind)
        {
            return await ShopContext_.OrdersTbls.FirstOrDefaultAsync(x => x.OrderId == ind);
        }

        public async Task<OrdersTbl> invite(OrdersTbl order)
        {
            await ShopContext_.OrdersTbls.AddAsync(order);
            await ShopContext_.SaveChangesAsync();
            return await ShopContext_.OrdersTbls.FindAsync(order.OrderId);
        }

    }
}
