using MediatR;
using System;
using FT.Persistence;
using System.Threading.Tasks;
using System.Threading;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;

namespace FT.Commands.Fridger.Update
{
    public class UpdateFridgeCommandHandler : IRequestHandler<UpdateFridgeCommand, Fridge>
    {

        private IUnitOfWork _unit;
        private IFridgeRepository _fridgeRepository;

        public UpdateFridgeCommandHandler(IUnitOfWork unit, IFridgeRepository fridgeRepository)
        {

            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
            _fridgeRepository = fridgeRepository ?? throw new ArgumentNullException(nameof(fridgeRepository));

        }

        public async Task<Fridge> Handle(UpdateFridgeCommand command, CancellationToken cancellationToken)
        {
                var fridge = await _fridgeRepository.FindByIdAsync(command.Id);

                if (fridge == null)
                {
                    throw new Exception("Сould not be emty.");
                }

                else
                {
                    fridge.Name = command.Name;
                    fridge.Model = command.Model;
                    fridge.Volume = command.Volume;
                    _fridgeRepository.Update(fridge);
                    await _unit.SaveAsync();
                    return fridge;
                }

        }
    }
}
