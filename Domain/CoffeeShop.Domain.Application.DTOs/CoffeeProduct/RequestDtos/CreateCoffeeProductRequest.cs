using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Domain.Application.DTOs.CoffeeProduct.RequestDtos
{
    public class CreateCoffeeProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType("decimal(16 ,3)")]
        public decimal Price { get; set; }
        public string Origin { get; set; }

      
    }
}
