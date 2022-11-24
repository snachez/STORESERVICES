using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STORESERVICES.API.BOOK.SERVICES.DTO;
using STORESERVICES.API.BOOK.SERVICES.DTO.Request;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace STORESERVICES.API.BOOK.Controllers
{
    [SwaggerTag("Web API for book maintenance.")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {

        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(Summary = "Endpoint to create a new book.", Description = "Returns an Unit\n\n **Sample request**\n\n ``` \n{\r\n  \"titulo\": \"El Código da Vinci\",\r\n  \"fechaPublicacion\": \"2003-04-18T18:50:14.063Z\",\r\n  \"autorLibro\": \"bee9bfda-340e-4c94-baaf-175772fd1b99\"\r\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(Unit))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(Unit))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Unit>> CreateBook([FromBody, SwaggerRequestBody("object of type book", Required = true)] NewBook data)
        {

            return await _mediator.Send(data);
        }

        [SwaggerOperation(Summary = "Endpoint to returns all books.", Description = "Returns a list authors\n\n **Sample Output**\n\n ``` \n{\r\n    \"libreriaMaterialId\": \"e7ff889e-8525-4417-9756-08daa1989575\",\r\n    \"titulo\": \"Harry potter\",\r\n    \"fechaPublicacion\": \"2022-09-28T00:00:00\",\r\n    \"autorLibro\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\"\r\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(List<LibroMaterialDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(List<LibroMaterialDto>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<LibroMaterialDto>>> GetAllBook()
        {
            return await _mediator.Send(new ListBook());
        }

        [SwaggerOperation(Summary = "Endpoint to return an book by LibreriaMaterialId.", Description = "Returns an author\n\n **Sample Output**\n\n ``` \n{\r\n    \"libreriaMaterialId\": \"e7ff889e-8525-4417-9756-08daa1989575\",\r\n    \"titulo\": \"Harry potter\",\r\n    \"fechaPublicacion\": \"2022-09-28T00:00:00\",\r\n    \"autorLibro\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\"\r\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(LibroMaterialDto))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(LibroMaterialDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<LibroMaterialDto>> GetByIdBook([FromRoute, SwaggerParameter("Id (GUID) of the Book type object", Required = true)] Guid id)
        {
            return await _mediator.Send(new UniqueBook { LibroId = id });
        }

    }
}
