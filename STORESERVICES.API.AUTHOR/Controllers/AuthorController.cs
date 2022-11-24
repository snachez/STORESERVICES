using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STORESERVICES.API.AUTHOR.SERVICES.DTO;
using STORESERVICES.API.AUTHOR.SERVICES.DTO.Request;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace STORESERVICES.API.AUTHOR.Controllers
{
    [SwaggerTag("Web API for author maintenance.")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(Summary = "Endpoint to create a new author.", Description = "Returns an Unit\n\n **Sample request**\n\n ``` \n{\r\n  \"nombre\": \"Dan\",\r\n  \"apellido\": \"Brown\",\r\n  \"fechaNacimiento\": \"2022-11-23T21:32:08.692Z\",\r\n  \"autorLibroGuid\": \"bee9bfda-340e-4c94-baaf-175772fd1b99\"\r\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(Unit))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(Unit))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Unit>> CreateAuthorBook([FromBody, SwaggerRequestBody("object of type author", Required = true)] AuthorBook data)
        {
            return await _mediator.Send(data);
        }

        [SwaggerOperation(Summary = "Endpoint to returns all authors.", Description = "Returns a list authors\n\n **Sample Output**\n\n ``` \n{\n   \"nombre\":\"Antoine\",\n   \"apellido\":\"Saint-Exupéry\",\n   \"fechaNacimiento\":\"1944-07-31T20:32:04.629Z\",\n   \"autorLibroGuid\":\"E5F9CBC6-B91C-4CF5-B049-7D50B76A17C8\"\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(List<AutorDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(List<AutorDto>))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<AutorDto>>> GetAllAuthorBook()
        {

            return await _mediator.Send(new ListaAutor());
        }

        [SwaggerOperation(Summary = "Endpoint to return an author by AutorLibroGuid.", Description = "Returns an author\n\n **Sample Output**\n\n ``` \n{\n   \"nombre\":\"Antoine\",\n   \"apellido\":\"Saint-Exupéry\",\n   \"fechaNacimiento\":\"1944-07-31T20:32:04.629Z\",\n   \"autorLibroGuid\":\"E5F9CBC6-B91C-4CF5-B049-7D50B76A17C8\"\n}\n ```")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(AutorDto))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(AutorDto))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized. The JWT Access Token has not been indicated or is incorrect.")]
        [Produces("application/json")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AutorDto>> GetAuthorBook([FromRoute, SwaggerParameter("Id (GUID) of the Author type object", Required = true)] string id)
        {
            return await _mediator.Send(new AutorUnico { AutorGuid = id });
        }


    }
}
