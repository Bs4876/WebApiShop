using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<(List<ProductsTbl> products, int total)> getProducts(int?[] categoryIds, int? minPrice, int? maxPrice, int position, int skip);
    }
}