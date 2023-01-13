using CoffeeShop.Domain.Application.DTOs.CoffeeProduct.RequestDtos;
using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Commands
{
    public class CreateCoffeeProductCommand:IRequest<Result>
    {
        public CreateCoffeeProductRequest CreateCoffeeProductRequest { get; set; }
    }
}
