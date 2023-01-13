using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.RequestDtos;
using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Commands
{
    public class UpdateCoffeeProductCommand:IRequest<Result>
    {
        public string Id { get; set; }
        public UpdateCoffeeCategoryRequest UpdateCoffeeCategoryRequest { get; set; }
    }
}
