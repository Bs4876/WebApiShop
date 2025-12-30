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
        public async Task<PageResponseDTO<LessInfoProductDTO>> getProducts(int?[] categoryIds, int? minPrice, int? maxPrice, int position, int skip)
        {

            (List<ProductsTbl>, int) response = await _iProductRepository.getProducts(categoryIds, maxPrice, minPrice, position, skip);
            List<LessInfoProductDTO> data = _mapper.Map<List<ProductsTbl>, List<LessInfoProductDTO>>(response.Item1);
            PageResponseDTO<LessInfoProductDTO> pageResponse = new();
            pageResponse.Data = data;
            pageResponse.TotalItems = response.Item2;
            pageResponse.CurrentPage = position;
            pageResponse.PageSize = skip;
            pageResponse.HasPreviousPage = position > 1;
            int numOfPages = pageResponse.TotalItems / skip;
            if (pageResponse.TotalItems % skip != 0)
                numOfPages++;
            pageResponse.HasNextPage = position < numOfPages;
            return pageResponse;
        }
    }
}
