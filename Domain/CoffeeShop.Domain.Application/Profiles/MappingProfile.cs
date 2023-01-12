using AutoMapper;
using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.RequestDtos;
using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.ResponseDtos;
using CoffeeShop.Domain.Entities.DbEntities;

namespace CoffeeShop.Domain.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CoffeeCategory, CreateCoffeeCategoryRequest>().ReverseMap();
            CreateMap<CoffeeCategory, CoffeeCategoryDetail>().ReverseMap();
            CreateMap<CoffeeCategory, UpdateCoffeeCategoryRequest>().ReverseMap();
        }
    }
}
