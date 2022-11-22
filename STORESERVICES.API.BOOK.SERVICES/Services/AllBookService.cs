using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STORESERVICES.API.BOOK.SERVICES.DTO.Request;
using STORESERVICES.API.BOOK.SERVICES.DTO;
using AutoMapper;
using STORESERVICES.API.BOOK.MODEL.Entities;
using STORESERVICES.API.BOOK.DAO.Interfaces;

namespace STORESERVICES.API.BOOK.SERVICES.Services
{
    public class AllBookService
    {
        public class Manejador : IRequestHandler<ListBook, List<LibroMaterialDto>>
        {
            public readonly IBookDao _bookDao;
            private readonly IMapper _mapper;

            public Manejador(IBookDao bookDao, IMapper mapper)
            {
                _bookDao = bookDao ?? throw new ArgumentNullException(nameof(bookDao));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<List<LibroMaterialDto>> Handle(ListBook request, CancellationToken cancellationToken)
            {
                var libros = await _bookDao.QueryBook();
                var librosDto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(libros);
                return librosDto;
            }
        }

    }
}
