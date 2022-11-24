using MediatR;
using STORESERVICES.API.LOGINJWT.DAO.Interfaces;
using STORESERVICES.API.LOGINJWT.SERVICES.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.SERVICES.Services
{
    public class GenerateTokenJWT
    {
        public class Manejador : IRequestHandler<UsuarioLogin, string>
        {
            public readonly IGenerateJwtDao _generateJwtDao;
            public readonly IAuthenticateUserDao _authenticateUserDao;
            public Manejador(IGenerateJwtDao generateJwtDao, IAuthenticateUserDao authenticateUserDao)
            {
                _generateJwtDao = generateJwtDao ?? throw new ArgumentNullException(nameof(generateJwtDao));
                _authenticateUserDao = authenticateUserDao ?? throw new ArgumentNullException(nameof(authenticateUserDao));
            }

            public async Task<string> Handle(UsuarioLogin request, CancellationToken cancellationToken)
            {
                var usuario = _authenticateUserDao.Login(request);
                if (usuario == null)
                {
                    //throw new Exception("No se encontro el autor");
                    return "No se encontro el usuario";
                }

                var _Header = _generateJwtDao.NewHeader();
                var _Claims = _generateJwtDao.NewClaims(usuario);
                var _Payload = _generateJwtDao.NewPAYLOAD(_Claims);
                var _Token = _generateJwtDao.NewToken(_Header, _Payload);

                return _Token;
            }
        }
    }
}
