using STORESERVICES.API.LOGINJWT.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.DAO.Interfaces
{
    public interface IGenerateJwtDao
    {
        public JwtHeader NewHeader();
        public Claim[] NewClaims(UsuarioInfo usuarioInfo);
        public JwtPayload NewPAYLOAD(Claim[] claims);
        public string NewToken(JwtHeader header, JwtPayload payload);
    }
}
