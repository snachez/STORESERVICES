using MediatR;
using STORESERVICES.API.AUTHOR.DAO.Interfaces;
using STORESERVICES.API.AUTHOR.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.SERVICES.Services
{
    public class NewAuthorBookService
    {
        public class Manejador : IRequestHandler<AuthorBook>
        {
            public readonly IAuthorBookDao _authorBookDao;

            public Manejador(IAuthorBookDao authorBookDao)
            {
                _authorBookDao = authorBookDao ?? throw new ArgumentNullException(nameof(authorBookDao));
            }

            public async Task<Unit> Handle(AuthorBook request, CancellationToken cancellationToken)
            {
                var valor = await _authorBookDao.NewAuthorBook(request.Nombre, request.Apellido, request.FechaNacimiento, request.AutorLibroGuid);

                if (valor == -1)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el Autor del libro");
            }
        }
    }
}
