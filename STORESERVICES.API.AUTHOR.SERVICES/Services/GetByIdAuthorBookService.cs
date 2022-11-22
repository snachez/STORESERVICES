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
    public class GetByIdAuthorBookService
    {
        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            public readonly IAuthorBookDao _authorBookDao;
            private readonly IMapper _mapper;
            public Manejador(IAuthorBookDao authorBookDao, IMapper mapper)
            {
                _authorBookDao = authorBookDao ?? throw new ArgumentNullException(nameof(authorBookDao));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = _authorBookDao.QueryByIdAuthorBook(request.AutorGuid);
                if (autor == null)
                {
                    //throw new Exception("No se encontro el autor");
                    return new AutorDto();
                }

                var autorDto = _mapper.Map<AutorLibro, AutorDto>(autor);

                return autorDto;
            }
        }
    }
}
