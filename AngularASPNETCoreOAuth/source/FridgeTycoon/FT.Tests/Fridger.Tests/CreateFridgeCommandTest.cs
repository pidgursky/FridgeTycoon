using FT.Commands.Fridger.Create;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.Users;
using FT.Services.UserClaimService;
//using IoC;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FT.Tests
{
    public class Tests
    {
        private IRequestHandler<CreateFridgeCommand, Fridge> _createFridgeCommandHandler;
        private Mock<IUserRepository> _userRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IFridgeRepository> _fridgeRepository;
        private Mock<IUserClaimService> _userClaimService;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _fridgeRepository = new Mock<IFridgeRepository>();
            _userClaimService = new Mock<IUserClaimService>();

            _createFridgeCommandHandler = new CreateFridgeCommandHandler(
                _unitOfWork.Object,
                _userRepository.Object,
                _fridgeRepository.Object,
                _userClaimService.Object
                );
        }

        [Test]
        public async Task Handle_Valid()
        {
            var user = new User();
            var command = new CreateFridgeCommand
            {
                Name = "some_name",
                Model = "some_model",
                Volume = 1
            };

            _userRepository.Setup(x => x.FindByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            _fridgeRepository.Setup(x => x.CreateAsync(It.IsAny<Fridge>()));

            //Act
            var result = await _createFridgeCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            _userRepository.Verify(x => x.FindByIdAsync(It.IsAny<Guid>()), Times.Once);

            _fridgeRepository
                .Verify(x => x.CreateAsync(It.Is<Fridge>(f =>
                    f.Name == command.Name
                    && f.Model == command.Model
                    && f.Volume == command.Volume
                    && f.User == user)), Times.Once);

            _unitOfWork.Verify(x => x.SaveAsync(), Times.Once);

            Assert.IsInstanceOf<Fridge>(result);
            Assert.AreEqual(command.Name, result.Name);
            Assert.AreEqual(command.Model, result.Model);
            Assert.AreEqual(command.Volume, result.Volume);
            Assert.AreSame(user, result.User);
        }

        [Test]
        public async Task Handle_InValidUser()
        {
            var user = new User();
            var command = new CreateFridgeCommand
            {
                Name = "some_name",
                Model = "some_model",
                Volume = 1
            };

            _userRepository.Setup(x => x.FindByIdAsync(It.IsAny<Guid>())).Throws<Exception>();

            _fridgeRepository.Setup(x => x.CreateAsync(It.IsAny<Fridge>()));

            //Assert
            Assert.ThrowsAsync<Exception>(() => _createFridgeCommandHandler.Handle(command, CancellationToken.None));

            _userRepository.Verify(x => x.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public async Task Handle_NullInputParameter()
        {
            var user = new User();
            var command = new CreateFridgeCommand
            {
                Name = null,
                Model = "some_model",
                Volume = 1
            };

            _userRepository.Setup(x => x.FindByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            _fridgeRepository.Setup(x => x.CreateAsync(null));
            var result = _createFridgeCommandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsInstanceOf(typeof(ArgumentNullException), result);

            _userRepository.Verify(x => x.FindByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

        //public CreateFridgeCommandHandler(IUnitOfWork unit, IUserRepository user, IFridgeRepository fridgeRepository, IUserClaimService userClaimService)
        //{
        //    _unit = unit ?? throw new ArgumentNullException(nameof(unit));
        //    _user = user ?? throw new ArgumentNullException(nameof(user));
        //    _fridgeRepository = fridgeRepository ?? throw new ArgumentNullException(nameof(fridgeRepository));
        //    _userClaimService = userClaimService ?? throw new ArgumentNullException(nameof(userClaimService));
        //}
        [Test]
        public void CreateFridgeCommandHandler_ArgumentNullException()
        {
            //Act
            //var result = new CreateFridgeCommandHandler((IUnitOfWork)_unitOfWork, null, null,null);

            //Assert
            Assert.That(() => new CreateFridgeCommandHandler((IUnitOfWork)_unitOfWork, null, null, null), Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}