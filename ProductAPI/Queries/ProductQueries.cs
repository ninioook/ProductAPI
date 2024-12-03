using MediatR;
using ProductAPI.Dtos;
using ProductAPI.Entities;

namespace ProductAPI.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductListItemDto>>
    {

    }

    public class GetProductQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}