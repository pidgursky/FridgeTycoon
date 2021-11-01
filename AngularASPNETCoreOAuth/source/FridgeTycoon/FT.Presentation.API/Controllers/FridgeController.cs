using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FT.Commands.Fridger.Create;
using FT.Commands.Fridger.Update;
using FT.Queries.Fridger.Get;
using MediatR;
using FT.Commands.Fridger.Delete;
using FT.AuthServer.Infrastructure.Constants;


namespace FT.Presentation.API.Controllers
{
    public class FridgeController : BaseController
    {
        public FridgeController(IMediator mediator) : base(mediator)
        {
            
        }

        //[Authorize(Policy = "Consumer")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FridgeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update( UpdateFridgeCommand command)
        {

                var id = await Mediator.Send(command);

                return CreatedAtAction("Update", new { Id = id }, id);

        }


        //[Authorize(Policy = "Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FridgeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteFridgeByIdCommand { Id = id }));

        }

        //[Authorize(Policy = "Consumer")]
        [HttpPost]
        [ProducesResponseType(typeof(FridgeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateFridgeCommand command)
        {

            var id = await Mediator.Send(command);

            return CreatedAtAction("Create", new { Id = id }, id);

        }

        //[Authorize(Policy = "Consumer")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FridgeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetFridgeQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Policy = "Consumer")]
        [HttpGet]
        [ProducesResponseType(typeof(FridgeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return User.IsInRole(Roles.Admin) 
                    ? Ok(await Mediator.Send(new GetAllFridgesQuery())) 
                    : Ok(await Mediator.Send(new GetUserFridgeQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
