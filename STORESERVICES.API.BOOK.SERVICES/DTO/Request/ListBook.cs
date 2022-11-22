using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.SERVICES.DTO.Request
{
    public class ListBook : IRequest<List<LibroMaterialDto>>
    {

    }
}
