using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<ProductsTbl>> getProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page);
    }
}