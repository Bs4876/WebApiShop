using Entities;

namespace Services
{
    public interface ICategoriesServies
    {
        Task<List<CategoriesTbl>> getCategories();
    }
}