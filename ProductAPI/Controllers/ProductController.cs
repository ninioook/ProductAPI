using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Commands;
using ProductAPI.Entities;
using ProductAPI.Models;
using System.Reflection;
using ProductAPI.Queries;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductModel model)
        {
            await _mediator.Send(_mapper.Map<AddProductCommand>(model));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductModel model)
        {
            await _mediator.Send(_mapper.Map<UpdateProductCommand>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductQuery { Id = id });
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
    }
}
