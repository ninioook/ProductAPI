using AutoMapper;
using MediatR;
using ProductAPI.Commands;
using ProductAPI.Entities;
using ProductAPI.Repositories;

namespace ProductAPI.CommandHandlers
{
    public class OrderCommandHandlers : IRequestHandler<AddOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public OrderCommandHandlers(IMapper mapper, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _mapper = mapper;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task Handle(AddOrderCommand query, CancellationToken cancellationToken)
        {
            var stock = await _orderReadRepository.GetStock(query.ProductId);

            if (stock < query.Quantity)
            {
                throw new Exception("Not enough stock");
            }

            var order = _mapper.Map<Order>(query);
            order.Amount=order.Quantity*order.Price;
            await _orderWriteRepository.AddOrder(order);
        }
    }
}