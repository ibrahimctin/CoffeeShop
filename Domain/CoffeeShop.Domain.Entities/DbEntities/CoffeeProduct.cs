using CoffeeShop.Domain.Entities.DbEntities.Common;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Domain.Entities.DbEntities
{
    public class CoffeeProduct:BaseDomainEntity
    {
        public string CoffeeName { get; set; }
        public string Description { get; set; }
        [DataType("decimal(16 ,3)")]
        public decimal Price { get; set; }
        public string Origin { get; set; }
        public string CoffeeCategoryId { get; set; }

        public CoffeeCategory Name { get; set; }

        public ICollection<CoffeeCategory> CoffeeCategories { get; set; }
    }
}
