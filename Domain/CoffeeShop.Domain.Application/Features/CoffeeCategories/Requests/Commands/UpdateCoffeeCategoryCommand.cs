﻿using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.RequestDtos;
using CoffeeShop.Domain.Application.Helpers.Results;
using MediatR;

namespace CoffeeShop.Domain.Application.Features.CoffeeCategories.Requests.Commands
{
    public class UpdateCoffeeCategoryCommand:IRequest<Result>
    {

        public string Id { get; set; }
        public UpdateCoffeeCategoryRequest UpdateCoffeeCategoryRequest { get; set; }

    }


   
}
