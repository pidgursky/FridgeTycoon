using FT.Domain.Entities.FridgeAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Domain.Entities.Users
{
    //TODO: merge user concept
    public  class User : EntityBase
    {
        public User() : base()
        {
            Fridges = new HashSet<Fridge>();
        }
        public string Name { get; set; }

        public virtual ICollection<Fridge> Fridges { get; set; }

    }
}
