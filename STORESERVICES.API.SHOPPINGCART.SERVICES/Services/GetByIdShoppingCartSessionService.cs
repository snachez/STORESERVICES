using MediatR;
using STORESERVICES.API.SHOPPINGCART.DAO.Interfaces;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO;
using STORESERVICES.API.SHOPPINGCART.SERVICES.DTO.Request;
using STORESERVICES.API.SHOPPINGCART.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES.Services
{
    public class GetByIdShoppingCartSessionService
    {
        public class Manejador : IRequestHandler<UniqueShoppingCart, CarritoDto>
        {
            public readonly ICartSessionDao _cartSessionDao;
            public readonly ICartSessionDetailDao _cartSessionDetailDao;
            private readonly ILibrosService _libroService;

            public Manejador(ICartSessionDao cartSessionDao, ICartSessionDetailDao cartSessionDetailDao, ILibrosService libroService)
            {
                _cartSessionDao = cartSessionDao ?? throw new ArgumentNullException(nameof(cartSessionDao));
                _cartSessionDetailDao = cartSessionDetailDao ?? throw new ArgumentNullException(nameof(cartSessionDetailDao));
                _libroService = libroService ?? throw new ArgumentNullException(nameof(libroService));
            }

            public async Task<CarritoDto> Handle(UniqueShoppingCart request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _cartSessionDao.GetByIdCartSession(request.CartSessionId);
                var carritoSesionDetalle = await _cartSessionDetailDao.GetByIdCartSessionDetail(request.CartSessionId);

                var listaCarritoDto = new List<CarritoDetalleDto>();

                foreach (var libro in carritoSesionDetalle)
                {

                    var response = await _libroService.GetLibro(new Guid(libro));
                    if (response.resultado)
                    {
                        var objetoLibro = response.Libro;
                        var carritoDetalle = new CarritoDetalleDto
                        {
                            TituloLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        listaCarritoDto.Add(carritoDetalle);
                    }
                }

                var carritoSesionDto = new CarritoDto
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProductos = listaCarritoDto
                };

                return carritoSesionDto;
            }
        }

    }
}
