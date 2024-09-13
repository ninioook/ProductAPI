using AutoMapper;
using MediatR;
using ProductAPI.Commands;
using ProductAPI.Entities;
using ProductAPI.Repositories;

namespace ProductAPI.CommandHandlers
{
    public class ProductCommandHandlers :
        IRequestHandler<AddProductCommand>,
        IRequestHandler<UpdateProductCommand>,
        IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly ProductAbstractRepositories _productRepository;

        public ProductCommandHandlers(IMapper mapper, ProductAbstractRepositories productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(command);
            product.Id = Guid.NewGuid();

            await _productRepository.Add(product, cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateProductCommand query, CancellationToken cancellationToken)
        {
            var productExisting = await _productRepository.Get(query.Id, cancellationToken);;

            await _productRepository.Update(product, cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            await _productRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}