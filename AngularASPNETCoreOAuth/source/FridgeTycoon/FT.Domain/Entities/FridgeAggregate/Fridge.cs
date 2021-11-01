using FT.Domain.Entities.ProductAggregate;
using FT.Domain.Entities.Users;
using System.Collections.Generic;

namespace FT.Domain.Entities.FridgeAggregate
{
    public class Fridge : EntityBase
    {
        public Fridge() : base()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }
        public string Model { get; set; }
        public int Volume { get; set; }
        public User User { get; set; }

        //public Guid UserId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
