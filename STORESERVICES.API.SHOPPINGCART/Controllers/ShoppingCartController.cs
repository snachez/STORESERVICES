using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO.Request;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace STORESERVICES.API.SHOPPINGCART.Controllers
{
    [SwaggerTag("Web API for shoppingcart maintenance.")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(Summary = "Endpoint to create a new shoppingcart.", Description = "Returns an Unit\n\n **Sample request**\n\n ``` \n{ \r\n   \"DateCreationSession\": \"2022-01-01T15:10:10\",\r\n   \"ProductList\": [\r\n     {\r\n       \"libroId\": \"e7ff889e-8525-4417-9756-08daa1989575\",\r\n       \"tituloLibro\": \"Harry potter\",\r\n       \"autorLibro\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n       \"fechaPublicacion\": \"2022-09-28T00:00:00\"\r\n     },\r\n   ]\r\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(Unit))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(Unit))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Unit>> CreateShoppingCart([FromBody, SwaggerRequestBody("object of type shoppingcart", Required = true)] NewShoppingCart data)
        {
            return await _mediator.Send(data);
        }

        [SwaggerOperation(Summary = "Endpoint to return an shoppingcart by CarritoSesionId.", Description = "Returns an author\n\n **Sample Output**\n\n ``` \n{ \r\n  \"carritoId\": 1,\r\n   \"fechaCreacionSesion\": \"2022-01-01T15:10:10\",\r\n   \"listaProductos\": [\r\n     {\r\n       \"libroId\": \"83ab7a1d-08b4-4d8c-8117-ff19401276c0\",\r\n       \"tituloLibro\": \"señor de los anillos\",\r\n       \"autorLibro\": null,\r\n       \"fechaPublicacion\": \"1954-09-28T00:00:00\"\r\n     },\r\n   ]\r\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(CarritoDto))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(CarritoDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CarritoDto>> GetShoppingCart([FromRoute, SwaggerParameter("Id (GUID) of the shoppingcart type object", Required = true)] int id)
        {
            return await _mediator.Send(new UniqueShoppingCart { CartSessionId = id });
        }

    }
}
