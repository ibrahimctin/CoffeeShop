using AutoMapper;
using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.ResponseDtos;
using CoffeeShop.Domain.Application.DTOs.CoffeeProduct.ResponseDtos;
using CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Queries;
using CoffeeShop.Domain.Application.Helpers.Results;
using CoffeeShop.Domain.Application.Helpers.Results.ResponseMessages;
using CoffeeShop.Infrastructure.EfContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Domain.Application.Features.CoffeeProducts.Handlers.Queries
{
    public class GetCoffeeProductDetailRequestHandler : IRequestHandler<GetCoffeeProductDetailRequest, Result<CoffeeProductDetail>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetCoffeeProductDetailRequestHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public  async Task<Result<CoffeeProductDetail>> Handle(GetCoffeeProductDetailRequest request, CancellationToken cancellationToken)
        {

            var coffeeProductResult = await _context.CoffeeProducts.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (coffeeProductResult is null)
            {
                return Result<CoffeeProductDetail>.Failed(new BadRequestObjectResult(
                    new ApiMessage(ResponseMessage.CoffeeProductNotFound)));
            }


            var coffeeProductPayload = _mapper.Map<CoffeeProductDetail>(coffeeProductResult);

            return Result<CoffeeProductDetail>.SuccessFul(coffeeProductPayload);
        }
    }
}
