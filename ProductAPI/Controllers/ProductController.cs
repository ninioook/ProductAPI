using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Commands;
using ProductAPI.Dtos;
using ProductAPI.Entities;
using ProductAPI.Models;
using ProductAPI.Queries;
using ILogger = Serilog.ILogger;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductController(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductModel model, CancellationToken cancellationToken)
        {
            await _mediator.Send(_mapper.Map<AddProductCommand>(model), cancellationToken);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductModel model, CancellationToken cancellationToken)
        {
            await _mediator.Send(_mapper.Map<UpdateProductCommand>(model), cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(new GetProductQuery { Id = id }, cancellationToken);

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductListItemDto>>> GetAll(CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new GetProductsQuery(), cancellationToken);

            return Ok(products);
        }

        [HttpPost("testlogger")]
        public IActionResult TestLogger()
        {
            _logger.Information("This log is from the injected ILogger");
            return Ok();
        }

    }
}
