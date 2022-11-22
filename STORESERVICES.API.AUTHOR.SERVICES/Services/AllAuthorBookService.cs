using AutoMapper;
using MediatR;
using STORESERVICES.API.AUTHOR.DAO.Interfaces;
using STORESERVICES.API.AUTHOR.MODEL.Entities;
using STORESERVICES.API.AUTHOR.SERVICES.DTO;
using STORESERVICES.API.AUTHOR.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.SERVICES.Services
{
    public class AllAuthorBookService
    {
        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            public readonly IAuthorBookDao _authorBookDao;
            private readonly IMapper _mapper;

            public Manejador(IAuthorBookDao authorBookDao, IMapper mapper)
            {
                _authorBookDao = authorBookDao ?? throw new ArgumentNullException(nameof(authorBookDao));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {

                var autores = _authorBookDao.QueryAuthorBook();
                var autoresDto = _mapper.Map<List<AutorLibro>, List<AutorDto>>(autores);
                return autoresDto;
            }
        }
    }
}
