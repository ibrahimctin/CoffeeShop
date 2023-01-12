using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Commands
{
    public class DeleteCoffeeCategoryCommand:IRequest<Result>
    {
        public string Id { get; set; }
    }
}
