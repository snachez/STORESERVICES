using FluentValidation;
using STORESERVICES.API.BOOK.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.SERVICES.Common
{
    public class NewBookValidation : AbstractValidator<NewBook>
    {

        public NewBookValidation()
        {
            RuleFor(x => x.Titulo).NotEmpty();
            RuleFor(x => x.FechaPublicacion).NotEmpty();
            RuleFor(x => x.AutorLibro).NotEmpty();
        }
    }
}
