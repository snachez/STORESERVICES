using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES.DTO.Request
{
    public class NewShoppingCart : IRequest
    {
        public DateTime DateCreationSession { get; set; }

        public List<string> ProductList { get; set; }

    }
}
