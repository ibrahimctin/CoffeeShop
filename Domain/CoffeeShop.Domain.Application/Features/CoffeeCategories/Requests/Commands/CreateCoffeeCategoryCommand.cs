using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.RequestDtos;
using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Commands
{
    public class CreateCoffeeCategoryCommand:IRequest<Result>
    {
        public CreateCoffeeCategoryRequest CreateCoffeeCategoryRequest { get; set; }
    }
}
