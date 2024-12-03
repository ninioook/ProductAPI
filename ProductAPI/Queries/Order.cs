using MediatR;
using ProductAPI.Entities;

namespace ProductAPI.Queries
{
    public class GetOrdersQuery : IRequest<List<Order>>
    {

    }

    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; set; }
    }
}