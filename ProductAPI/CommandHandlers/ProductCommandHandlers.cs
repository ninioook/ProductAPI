using AutoMapper;
using MediatR;
using ProductAPI.Commands;
using ProductAPI.Entities;
using ProductAPI.Repositories;
using ILogger = Serilog.ILogger;

namespace ProductAPI.CommandHandlers
{
    public class ProductCommandHandlers :
        IRequestHandler<AddProductCommand>,
        IRequestHandler<UpdateProductCommand>,
        IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductCommandHandlers(IMapper mapper, ILogger logger, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(command);

            await _productWriteRepository.Add(product, command.CategoryIds);
        }

        public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            _ = await _productReadRepository.Get(command.Id)
                ?? throw new Exception("Product not found");

            var product = _mapper.Map<Product>(command);

            await _productWriteRepository.Update(product, command.CategoryIds);
        }

        public async Task Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var productExisting = await _productReadRepository.Get(command.Id)
                ?? throw new Exception("Product not found");

            await _productWriteRepository.Delete(command.Id);
        }
    }
}