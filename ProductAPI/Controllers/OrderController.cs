using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Commands;
using ProductAPI.Entities;
using ProductAPI.Models;
using ProductAPI.Queries;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddOrderModel model, CancellationToken cancellationToken)
        {
            await _mediator.Send(_mapper.Map<AddOrderCommand>(model), cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetById(int id, CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(new GetOrderByIdQuery { Id = id }, cancellationToken);

            return Ok(orders);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll(CancellationToken cancellationToken)
        {
            var orders = await _mediator.Send(new GetOrdersQuery(), cancellationToken);

            return Ok(orders);
        }
    }
}