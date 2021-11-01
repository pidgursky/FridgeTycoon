using FT.Domain.Entities.FridgeAggregate;
using MediatR;
using System;

namespace FT.Commands.Fridger.Create
{
    public class CreateFridgeCommand : IRequest<Fridge>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Volume { get; set; }
       
    }
}
