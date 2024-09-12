using MediatR;
using ProductAPI.Entities;

namespace ProductAPI.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {

    }

    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}