using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        ShopContext _ShopContext;
        public ProductRepository(ShopContext shopContext)
        {
            this._ShopContext = shopContext;
        }
        public async Task<List<ProductsTbl>> getProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            return await _ShopContext.ProductsTbls.ToListAsync();
        }
    }
}
