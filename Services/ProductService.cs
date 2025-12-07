using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductRepository, IProductService
    {
        IProductRepository _iProductRepository;

        public ProductService(IProductRepository iProductRepository)
        {
            this._iProductRepository = iProductRepository;
        }
        public async Task<List<ProductsTbl>> getProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            return await _iProductRepository.getProducts(categoryId, minPrice, maxPrice, limit, page);
        }
    }
}
