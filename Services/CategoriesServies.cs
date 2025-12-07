using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriesServies : ICategoryRepository, ICategoriesServies
    {
        ICategoryRepository _iCategoryRepository;

        public CategoriesServies(ICategoryRepository iCategoryRepository)
        {
            this._iCategoryRepository = iCategoryRepository;
        }
        public async Task<List<CategoriesTbl>> getCategories()
        {
            return await _iCategoryRepository.getCategories();
        }
    }
}
