using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
