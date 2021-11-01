using FT.Domain.Entities;
using MediatR;
using System;

namespace FT.Commands.Fridger.Delete
{
    public class DeleteFridgeByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
         
    }
}
