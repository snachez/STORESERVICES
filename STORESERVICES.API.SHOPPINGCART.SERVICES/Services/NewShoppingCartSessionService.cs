using MediatR;
using STORESERVICES.API.SHOPPINGCART.DAO.Interfaces;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES.Services
{
    public class NewShoppingCartSessionService
    {
        public class Manejador : IRequestHandler<NewShoppingCart>
        {
            public readonly ICartSessionDao _cartSessionDao;
            public readonly ICartSessionDetailDao _cartSessionDetailDao;
            public Manejador(ICartSessionDao cartSessionDao, ICartSessionDetailDao cartSessionDetailDao)
            {
                _cartSessionDao = cartSessionDao ?? throw new ArgumentNullException(nameof(cartSessionDao));
                _cartSessionDetailDao = cartSessionDetailDao ?? throw new ArgumentNullException(nameof(cartSessionDetailDao));
            }

            public async Task<Unit> Handle(NewShoppingCart request, CancellationToken cancellationToken)
            {
                var value = await _cartSessionDao.NewCartSession(request.DateCreationSession);

                if (value == 0)
                {
                    throw new Exception("Errores en la insercion del carrito de compras");
                }

                int id = value;


                foreach (var obj in request.ProductList)
                {
                    value = await _cartSessionDetailDao.NewCartSessionDetail(DateTime.Now, obj, id);
                }

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el detalle del carrito de compras");
            }
        }
    }
}
