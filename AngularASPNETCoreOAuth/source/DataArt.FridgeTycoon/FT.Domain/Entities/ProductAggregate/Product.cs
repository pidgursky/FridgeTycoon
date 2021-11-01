using FT.Domain.Entities.FridgeAggregate;

namespace FT.Domain.Entities.ProductAggregate
{
    public class Product : EntityBase
    {
        public Product() : base()
        {
        }
        public string Name { get; set; }
        public Fridge Fridge { get; set; }
        public RefrigeratorStatus Refrigeratory { get; set; }
    }
}
