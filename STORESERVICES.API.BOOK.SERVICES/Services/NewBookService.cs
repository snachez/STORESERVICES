using MediatR;
using STORESERVICES.API.BOOK.DAO.Interfaces;
using STORESERVICES.API.BOOK.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.SERVICES.Services
{
    public class NewBookService
    {
        public class Manejador : IRequestHandler<NewBook>
        {
            public readonly IBookDao _bookDao;
            public Manejador(IBookDao bookDao)
            {
                _bookDao = bookDao ?? throw new ArgumentNullException(nameof(bookDao));
            }
            public async Task<Unit> Handle(NewBook request, CancellationToken cancellationToken)
            {
                var value = await _bookDao.NewBook(request.Titulo, request.FechaPublicacion, request.AutorLibro);

                if (value == -1)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar el libro");

            }
        }

    }
}
