using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using STORESERVICES.API.LOGINJWT.MODEL.Entities;
using STORESERVICES.API.LOGINJWT.SERVICES.DTO.Request;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace STORESERVICES.API.LOGINJWT.Controllers
{
    [SwaggerTag("Web API for login maintenance.")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(Summary = "Endpoint to create a new token.", Description = "Return a Token")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Request Successful", Type = typeof(string))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Request failed", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("{Usuario}/{Password}")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromRoute, SwaggerParameter("Usuario of the UsuarioLogin type object", Required = true)] string Usuario, [FromRoute, SwaggerParameter("Password of the UsuarioLogin type object", Required = true)] string Password)
        {
            return await _mediator.Send(new UsuarioLogin { Usuario = Usuario, Password = Password });
        }
    }
}
