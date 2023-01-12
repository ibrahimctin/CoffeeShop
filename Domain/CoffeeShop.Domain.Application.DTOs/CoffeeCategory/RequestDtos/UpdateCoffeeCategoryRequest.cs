using CoffeeShop.Domain.Application.DTOs.Common;

namespace CoffeeShop.Domain.Application.DTOs.CoffeeCategory.RequestDtos
{
    public class UpdateCoffeeCategoryRequest:BaseDto
    {
     
        public string Name { get; set; }
    }
}
