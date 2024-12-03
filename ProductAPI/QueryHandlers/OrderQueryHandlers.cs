using MediatR;
using ProductAPI.Entities;
using ProductAPI.Queries;

namespace ProductAPI.QueryHandlers
{
    public class OrderQueryHandlers : IRequestHandler<GetOrdersQuery, List<Order>>
    {
        public Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}