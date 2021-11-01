using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FT.Commands.Products.Create;
using FT.Queries.Productor.Get;
using FT.Commands.Products.Update;
using FT.Commands.Products.Delete;
using MediatR;


namespace FT.Presentation.API.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {

        }
        //[Authorize(Policy = "Consumer")]
        [HttpPost]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {

            var id = await Mediator.Send(command);          

            return CreatedAtAction("Create", new { Id = id }, id);
        }

        //[Authorize(Policy = "Consumer")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetProductQuery { Id = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Update( UpdateProductCommand command)
        {

            var id = await Mediator.Send(command);

            return CreatedAtAction("Update", new { Id = id }, id);
        }


        //[Authorize(Policy = "Consumer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));

        }



        [HttpGet]
        [Route("/api/product/get/fridge/{fridgeId}")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFridgeProduct(Guid fridgeId)
        {
            try
            {

                return Ok(await Mediator.Send(new GetFridgeProductQuery { FridgeId = fridgeId }));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
