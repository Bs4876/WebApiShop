using DTOs;
using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<LessInfoProductDTO>> getProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page);
    }
}