using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Commands;
using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([Required] string name, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddCategoryCommand { Name = name }, cancellationToken);
            return Ok();
        }
    }
}
