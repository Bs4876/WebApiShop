using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService: IProductService
    {
        IProductRepository _iProductRepository;
        IMapper _mapper;

        public ProductService(IProductRepository iProductRepository, IMapper mapper)
        {
            this._iProductRepository = iProductRepository;
            this._mapper = mapper;
        }
        public async Task<List<LessInfoProductDTO>> getProducts(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            List<ProductsTbl> products= await _iProductRepository.getProducts(categoryId, minPrice, maxPrice, limit, page);
            List<LessInfoProductDTO> productDTos=_mapper.Map< List<ProductsTbl> ,List <LessInfoProductDTO>>(products);
            return productDTos;
        }
    }
}
