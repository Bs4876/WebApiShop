using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<ProductsTbl>> getProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page);
    }
}