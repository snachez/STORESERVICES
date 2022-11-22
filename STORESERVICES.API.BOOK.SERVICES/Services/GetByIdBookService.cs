using AutoMapper;
using MediatR;
using STORESERVICES.API.BOOK.DAO.Interfaces;
using STORESERVICES.API.BOOK.MODEL.Entities;
using STORESERVICES.API.BOOK.SERVICES.DTO;
using STORESERVICES.API.BOOK.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.SERVICES.Services
{
    public class GetByIdBookService
    {
        public class Manejador : IRequestHandler<UniqueBook, LibroMaterialDto>
        {
            public readonly IBookDao _bookDao;
            private readonly IMapper _mapper;

            public Manejador(IBookDao bookDao, IMapper mapper)
            {
                _bookDao = bookDao ?? throw new ArgumentNullException(nameof(bookDao));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
            public async Task<LibroMaterialDto> Handle(UniqueBook request, CancellationToken cancellationToken)
            {
                var libro = await _bookDao.QueryByIdBook(request.LibroId);
                if (libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }

                var libroDto = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(libro);
                return libroDto;
            }
        }

    }
}
