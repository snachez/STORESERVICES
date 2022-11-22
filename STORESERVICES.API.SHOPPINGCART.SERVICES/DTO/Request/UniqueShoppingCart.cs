using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES.DTO.Request
{
    public class UniqueShoppingCart : IRequest<CarritoDto>
    {
        public int CartSessionId { get; set; }
    }
}
