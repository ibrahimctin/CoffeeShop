using AutoMapper;
using CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Commands;
using CoffeeShop.Domain.Application.Helpers.Results;
using CoffeeShop.Domain.Entities.DbEntities;
using CoffeeShop.Infrastructure.EfContext;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeCategories.Handlers.Commands
{
    public class CreateCoffeeCategoryCommandHandler : IRequestHandler<CreateCoffeeCategoryCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CreateCoffeeCategoryCommandHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result> Handle(CreateCoffeeCategoryCommand request, CancellationToken cancellationToken)
        {
            var coffeeCategory = _mapper.Map<CoffeeCategory>(request.CreateCoffeeCategoryRequest);
            await _context.AddAsync(coffeeCategory);
            await _context.SaveChangesAsync();

            return Result.SuccessFul();
        }
    }
}
