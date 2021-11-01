using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FT.Domain.Entities;
using System;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.Users;
using FT.Services.UserClaimService;
//using FT.Presentation.API.Validator;
namespace FT.Commands.Fridger.Create
{
    public class CreateFridgeCommandHandler : IRequestHandler<CreateFridgeCommand, Fridge>
    {
        private IUserRepository _user;
        private IUnitOfWork _unit;

        private IFridgeRepository _fridgeRepository;
        private IUserClaimService _userClaimService;
        //private IFridgeValidator _fridgeValidator;

        public CreateFridgeCommandHandler(IUnitOfWork unit, IUserRepository user, IFridgeRepository fridgeRepository, IUserClaimService userClaimService)
        {
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _fridgeRepository = fridgeRepository ?? throw new ArgumentNullException(nameof(fridgeRepository));
            _userClaimService = userClaimService ?? throw new ArgumentNullException(nameof(userClaimService));

        }

        public async Task<Fridge> Handle(CreateFridgeCommand command, CancellationToken cancellationToken)
        {                       
            var fridge = new Fridge();
            fridge.Name = command.Name;
            fridge.Model = command.Model;
            fridge.Volume = command.Volume;
            fridge.User = await _user.FindByIdAsync(_userClaimService.UserId);
            //throw new Exception("Test exeption");
            await _fridgeRepository.CreateAsync(fridge);
            await _unit.SaveAsync();
            return fridge;
        }

    }
}
