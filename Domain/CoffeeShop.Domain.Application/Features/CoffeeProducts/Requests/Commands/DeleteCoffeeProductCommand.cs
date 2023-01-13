using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Commands
{
    public class DeleteCoffeeProductCommand:IRequest<Result>
    {
        public string Id { get; set; }
    }
}
