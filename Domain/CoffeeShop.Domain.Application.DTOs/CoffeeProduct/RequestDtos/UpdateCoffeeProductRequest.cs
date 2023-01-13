using CoffeeShop.Domain.Application.DTOs.CoffeeCategory.ResponseDtos;
using CoffeeShop.Domain.Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Domain.Application.DTOs.CoffeeProduct.RequestDtos
{
    public class UpdateCoffeeProductRequest:BaseDto
    {
        public string CoffeeName { get; set; }
        public string Description { get; set; }
        [DataType("decimal(16 ,3)")]
        public decimal Price { get; set; }
        public string Origin { get; set; }
        public string CoffeeCategoryId { get; set; }

        public CoffeeCategoryDetail Name { get; set; }

    }
}
