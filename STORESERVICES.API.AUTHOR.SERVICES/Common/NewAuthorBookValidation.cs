using FluentValidation;
using STORESERVICES.API.AUTHOR.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.SERVICES.Common
{
    public class NewAuthorBookValidation : AbstractValidator<AuthorBook>
    {
        public NewAuthorBookValidation()
        {
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.Apellido).NotEmpty();
        }
    }
}
