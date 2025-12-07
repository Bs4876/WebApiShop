using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoriesServies _categoriesServies;
        public CategoryController(ICategoriesServies categoriesServies)
        {
            _categoriesServies = categoriesServies;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoriesTbl>> getCategories()
        {
            return await _categoriesServies.getCategories();
        }

    }
}
