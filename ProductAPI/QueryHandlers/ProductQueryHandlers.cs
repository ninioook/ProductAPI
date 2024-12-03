using AutoMapper;
using MediatR;
using ProductAPI.Dtos;
using ProductAPI.Queries;
using ProductAPI.Repositories;

namespace ProductAPI.QueryHandlers
{
    public class ProductQueryHandlers :
        IRequestHandler<GetProductQuery, ProductDto>,
        IRequestHandler<GetProductsQuery, IEnumerable<ProductListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;

        public ProductQueryHandlers(IMapper mapper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<ProductDto> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.Get(query.Id);
            var productCategories = await _productReadRepository.GetProductCategoriesById(query.Id);

            var productDto = _mapper.Map<ProductDto>(product);
            productDto.Categories = productCategories;

            return productDto;
        }

        public async Task<IEnumerable<ProductListItemDto>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _productReadRepository.GetAllProducts();
            var productCategories = await _productReadRepository.GetAllProductCategories();

            var productDtos = products.Select(product => new ProductListItemDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Categories = productCategories
                    .Where(pc => pc.ProductId == product.Id)
                    .Select(pc => pc.CategoryName)
            }).ToList();

            return productDtos;
        }
    }
}