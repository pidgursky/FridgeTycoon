using MediatR;
using System;
using FT.Persistence;
using System.Threading.Tasks;
using System.Threading;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;

namespace FT.Commands.Fridger.Delete
{
    public class DeleteFridgeByIdCommandHandler : IRequestHandler<DeleteFridgeByIdCommand, Guid>
    {

        private IUnitOfWork _unit;
        private IFridgeRepository _fridgeRepository;


        public DeleteFridgeByIdCommandHandler(IUnitOfWork unit, IFridgeRepository fridgeRepository)
        {
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
            _fridgeRepository = fridgeRepository ?? throw new ArgumentNullException(nameof(fridgeRepository));

        }

        public async Task<Guid> Handle(DeleteFridgeByIdCommand command, CancellationToken cancellationToken)
        {
            var fridge = await _fridgeRepository.FindByIdAsync(command.Id);
            _fridgeRepository.Remove(fridge);
            await _unit.SaveAsync();
            return fridge.Id;
        }
    }
}
