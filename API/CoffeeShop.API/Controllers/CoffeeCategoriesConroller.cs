using CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Commands;
using CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeCategoriesConroller : ControllerBase
    {

        private readonly IMediator _mediator;

        public CoffeeCategoriesConroller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCoffee")]
        public async Task<IActionResult> CreateCoffeeCategory([FromBody] CreateCoffeeCategoryCommand createCoffeeCategoryCommand)
        {
            var result = await _mediator.Send(createCoffeeCategoryCommand);

            //if (result.Success == false)
            //{
            //    return result.ApiResult;
            //}

            //return NoContent();

            return result.Success is false ? result.ApiResult : NoContent();
        }

        [HttpGet("GetCoffeeCategoryById")]
        public async Task<IActionResult> GetCoffeeCategoryById(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCoffeeCategoryRequest { Id = id }, cancellationToken);

            return result.ApiResult;
        }

        [HttpPost("UpdateCoffeeCategory")]
        public async Task<IActionResult> UpdateCoffeeCategory([FromBody] UpdateCoffeeCategoryCommand updateCoffeeCategoryCommand)
        {
            var result = await _mediator.Send(updateCoffeeCategoryCommand);

            return result.Success is false ? result.ApiResult : NoContent();
        }

        [HttpDelete("DeleteCoffeeCategory")]
        public async Task<IActionResult> DeleteCoffeeCategory(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteCoffeeCategoryCommand { Id = id }, cancellationToken);

            return result.ApiResult;
        }
    }
}
