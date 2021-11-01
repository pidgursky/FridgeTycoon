using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using MediatR;
using System;

namespace FT.Commands.Fridger.Update
{
    public class UpdateFridgeCommand : IRequest<Fridge>
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Model { get; set; }
        public int Volume { get; set; }     

    }
}
