using System;
using System.Linq.Expressions;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;

namespace FT.Queries.Fridger.Get
{
    public class FridgeViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Volume { get; set; }


    public static Expression<Func<Fridge, FridgeViewModel>> Projection
    {
        get
        {
            return  p => new FridgeViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Model = p.Model,
                Volume = p.Volume
            };
        }
    }

    public static FridgeViewModel Create(Fridge product)
    {
        return Projection.Compile().Invoke(product);
    }
}
}
