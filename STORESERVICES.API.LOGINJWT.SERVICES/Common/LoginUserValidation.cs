using FluentValidation;
using STORESERVICES.API.LOGINJWT.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.SERVICES.Common
{
    public class LoginUserValidation : AbstractValidator<UsuarioLogin>
    {
        public LoginUserValidation()
        {
            RuleFor(x => x.Usuario).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
