using AutoMapper;
using CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Commands;
using CoffeeShop.Domain.Application.Helpers.Results;
using CoffeeShop.Domain.Application.Helpers.Results.ResponseMessages;
using CoffeeShop.Domain.Entities.DbEntities;
using CoffeeShop.Infrastructure.EfContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Domain.Application.Features.CoffeeProducts.Handlers.Commands
{
    public class UpdateCoffeeProductCommandHandler : IRequestHandler<UpdateCoffeeProductCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UpdateCoffeeProductCommandHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result> Handle(UpdateCoffeeProductCommand request, CancellationToken cancellationToken)
        {
            var coffeeProduct = await GetCoffeeProduct(request.Id);
            if (coffeeProduct is null)
            {
                return Result.Failed(new BadRequestObjectResult(
                    new ApiMessage(ResponseMessage.CoffeeProductNotFound)));
            }

            var coffeeProductPayload = _mapper.Map<CoffeeProduct>(coffeeProduct);
            _context.Update(coffeeProductPayload);
            await _context.SaveChangesAsync();

            return Result.SuccessFul();
            
           
        }


        private Task<CoffeeProduct> GetCoffeeProduct(string id) => _context.CoffeeProducts
            .Include(ğ => ğ.CoffeeCategories)
            .SingleOrDefaultAsync(ğ => ğ.Id == id);
    }


}
