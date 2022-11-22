using MediatR;
using Microsoft.AspNetCore.Mvc;
using STORESERVICES.API.BOOK.SERVICES.DTO;
using STORESERVICES.API.BOOK.SERVICES.DTO.Request;
using System.Net;

namespace STORESERVICES.API.BOOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {

        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Unit))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Unit))]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateBook(NewBook data)
        {

            return await _mediator.Send(data);
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<LibroMaterialDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(List<LibroMaterialDto>))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<LibroMaterialDto>>> GetAllBook()
        {
            return await _mediator.Send(new ListBook());
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LibroMaterialDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(LibroMaterialDto))]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroMaterialDto>> GetByIdBook(Guid id)
        {
            return await _mediator.Send(new UniqueBook { LibroId = id });
        }

    }
}
