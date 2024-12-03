using MediatR;

namespace ProductAPI.Commands
{
    public class AddOrderCommand : IRequest
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}