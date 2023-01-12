using AutoMapper;
using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.ResponseDtos;
using CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Queries;
using CoffeeShop.Domain.Application.Helpers.Results;
using CoffeeShop.Domain.Application.Helpers.Results.ResponseMessages;
using CoffeeShop.Infrastructure.EfContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Domain.Application.Features.CoffeeCategories.Handlers.Queries
{
    public class GetCoffeeCategoryRequestHandler : IRequestHandler<GetCoffeeCategoryRequest, Result<CoffeeCategoryDetail>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public GetCoffeeCategoryRequestHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<CoffeeCategoryDetail>> Handle(GetCoffeeCategoryRequest request, CancellationToken cancellationToken)
        {
            var coffeeCategoryResult = await _context.CoffeeCategories.SingleOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

            if (coffeeCategoryResult is null)
            {
                return Result<CoffeeCategoryDetail>.Failed(new BadRequestObjectResult(
                    new ApiMessage(ResponseMessage.CoffeeCategoryNotFound)));
            }

            var coffeeCategoryResultPayload = _mapper.Map<CoffeeCategoryDetail>(coffeeCategoryResult);

            return Result<CoffeeCategoryDetail>.SuccessFul(coffeeCategoryResultPayload);
        }
    }
}
