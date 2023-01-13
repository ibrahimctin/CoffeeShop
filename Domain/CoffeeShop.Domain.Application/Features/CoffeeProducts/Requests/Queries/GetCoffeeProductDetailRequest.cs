using CoffeeShop.Domain.Application.DTOs.CoffeeProduct.ResponseDtos;
using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Queries
{
    public class GetCoffeeProductDetailRequest:IRequest<Result<CoffeeProductDetail>>
    {
        public string Id { get; set; }
    }
}
