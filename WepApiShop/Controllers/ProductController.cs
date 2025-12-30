using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _iProductService;
        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<PageResponseDTO<LessInfoProductDTO>> getProducts([FromQuery] int?[] categoryIds,int? minPrice, int? maxPrice, int position, int skip)
        {
            
            return await _iProductService.getProducts(categoryIds, minPrice, maxPrice, position, skip);
        }
    }
}
