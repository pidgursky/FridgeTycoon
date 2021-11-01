using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using ProductItem = FT.Domain.Entities.ProductAggregate.Product;

namespace FT.Queries.Productor.Get
{
    public class ProductViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public Fridge Fridge { get; set; }
        public RefrigeratorStatus Refrigeratory { get; set; }
        public bool EditEnabled { get; set; }

        public static Expression<Func<ProductItem, ProductViewModel>> Projection
        {
            get
            {
                return p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Fridge=p.Fridge,
                    Refrigeratory=p.Refrigeratory
                };
            }
        }

        public static ProductViewModel Create(ProductItem product)
        {
            return Projection.Compile().Invoke(product);
        }

    }
}
