using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.ResponseDtos;
using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Queries
{
    public class GetCoffeeCategoryRequest:IRequest<Result<CoffeeCategoryDetail>>
    {
        public string Id { get; set; }
    }
}
