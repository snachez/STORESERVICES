using MediatR;
using Microsoft.AspNetCore.Mvc;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO.Request;
using System.Net;

namespace STORESERVICES.API.SHOPPINGCART.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Unit))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Unit))]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateShoppingCart(NewShoppingCart data)
        {
            return await _mediator.Send(data);
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CarritoDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(CarritoDto))]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoDto>> GetShoppingCart(int id)
        {
            return await _mediator.Send(new UniqueShoppingCart { CartSessionId = id });
        }

    }
}
