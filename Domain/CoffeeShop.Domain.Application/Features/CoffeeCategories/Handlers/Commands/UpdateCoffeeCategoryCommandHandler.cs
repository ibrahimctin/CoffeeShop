using AutoMapper;
using CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Commands;
using CoffeeShop.Domain.Application.Helpers.Results;
using CoffeeShop.Domain.Application.Helpers.Results.ResponseMessages;
using CoffeeShop.Domain.Entities.DbEntities;
using CoffeeShop.Infrastructure.EfContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Domain.Application.Features.CoffeeCategories.Handlers.Commands
{
    public class UpdateCoffeeCategoryCommandHandler : IRequestHandler<UpdateCoffeeCategoryCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UpdateCoffeeCategoryCommandHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result> Handle(UpdateCoffeeCategoryCommand request, CancellationToken cancellationToken)
        {
            var coffeeCategory = await GetCoffeeCategory(request.Id);
            if (coffeeCategory is null)
            {
                return Result.Failed(new BadRequestObjectResult(
                    new ApiMessage(ResponseMessage.CoffeeCategoryNotFound)));
            }
            var coffeeCategoryPayload = _mapper.Map<CoffeeCategory>(coffeeCategory);
            _context.Update(coffeeCategoryPayload);
            await _context.SaveChangesAsync();

            return Result.SuccessFul();
           

        }
        private async Task<CoffeeCategory> GetCoffeeCategory(string id) => await _context.CoffeeCategories.SingleOrDefaultAsync(ğ => ğ.Id == id);
    }
}
