using MediatR;

namespace ProductAPI.Commands
{
    public class AddProductCommand : IRequest
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }

    public class UpdateProductCommand : IRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<int> CategoryIds { get; set; }
    }

    public class DeleteProductCommand : IRequest
    {
        public string Id { get; set; }
    }
}
