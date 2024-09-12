using MediatR;
using ProductAPI.Commands;
using ProductAPI.Entities;

namespace ProductAPI.CommandHandlers
{
    public class ProductCommandHandlers :
        IRequestHandler<AddProductCommand>,
        IRequestHandler<UpdateProductCommand>,  
        IRequestHandler<DeleteProductCommand>
    {
        
        public ProductCommandHandlers()
        {
          
        }

        public async Task<Unit> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating product with name: {Name}", command.Name);

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
                ImageUrl = command.ImageUrl,
                Categories = command.Categories
            };

            await _productRepository.AddAsync(product);
            _logger.LogInformation("Product created with ID: {Id}", product.Id);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating product with ID: {Id}", request.Id);

            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                Categories = request.Categories
            };

            await _productRepository.UpdateAsync(product);
            _logger.LogInformation("Product updated with ID: {Id}", request.Id);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting product with ID: {Id}", request.Id);

            await _productRepository.DeleteAsync(request.Id);
            _logger.LogInformation("Product deleted with ID: {Id}", request.Id);

            return Unit.Value;
        }
    }
}