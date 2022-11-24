using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.SERVICES.DTO.Request
{
    public class UsuarioLogin : IRequest<string>
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
