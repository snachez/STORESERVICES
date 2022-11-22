using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.SERVICES.DTO.Request
{
    public class AutorUnico : IRequest<AutorDto>
    {
        public string AutorGuid { get; set; }
    }
}
