using AutoMapper;
using CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Commands;
using CoffeeShop.Domain.Application.Features.CoffeeProducts.Requests.Commands;
using CoffeeShop.Domain.Application.Helpers.Results;
using CoffeeShop.Domain.Entities.DbEntities;
using CoffeeShop.Infrastructure.EfContext;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeProducts.Handlers.Commands
{
    public class CreateCoffeeProductCommandHandler : IRequestHandler<CreateCoffeeProductCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CreateCoffeeProductCommandHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result> Handle(CreateCoffeeProductCommand request, CancellationToken cancellationToken)
        {
            var coffeeProduct = _mapper.Map<CoffeeProduct>(request.CreateCoffeeProductRequest);

            await _context.AddAsync(coffeeProduct);
            await _context.SaveChangesAsync();

            return Result.SuccessFul();

        }
    }
}
