using CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Commands;
using CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoffeeProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateCoffeeProduct")]
        public async Task<IActionResult> CreateCoffeeProduct([FromBody] CreateCoffeeProductCommand createCoffeeProductCommand)
        {
            var result = await _mediator.Send(createCoffeeProductCommand);
            return result.Success is false ? result.ApiResult : NoContent();
        }

        [HttpGet("GetCoffeeProductById")]
        public async Task<IActionResult> GetCoffeeProductById(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCoffeeProductDetailRequest { Id = id }, cancellationToken);

            return result.ApiResult;
        }

        [HttpPost("UpdateCoffeeProduct")]
        public async Task<IActionResult> UpdateCoffeeProduct([FromBody] UpdateCoffeeProductCommand updateCoffeeProductCommand)
        {
            var result = await _mediator.Send(updateCoffeeProductCommand);

            return result.Success is false ? result.ApiResult : NoContent();
        }

        [HttpDelete("DeleteCoffeeProduct")]
        public async Task<IActionResult> DeleteCoffeeProduct(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteCoffeeProductCommand { Id = id }, cancellationToken);

            return result.ApiResult;
        }
    }
}
