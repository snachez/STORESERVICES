using MediatR;
using Microsoft.AspNetCore.Mvc;
using STORESERVICES.API.AUTHOR.SERVICES.DTO;
using STORESERVICES.API.AUTHOR.SERVICES.DTO.Request;
using System.Net;

namespace STORESERVICES.API.AUTHOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Unit))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Unit))]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateAuthorBook(AuthorBook data)
        {
            return await _mediator.Send(data);
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<AutorDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(List<AutorDto>))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAllAuthorBook()
        {

            return await _mediator.Send(new ListaAutor());
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AutorDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(AutorDto))]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAuthorBook(string id)
        {
            return await _mediator.Send(new AutorUnico { AutorGuid = id });
        }


    }
}
