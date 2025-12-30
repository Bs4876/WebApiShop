using DTOs;
using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<PageResponseDTO<LessInfoProductDTO>> getProducts(int?[] categoryIds, int? minPrice, int? maxPrice, int position, int skip);
    }
}