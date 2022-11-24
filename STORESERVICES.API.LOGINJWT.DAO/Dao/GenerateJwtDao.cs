using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using STORESERVICES.API.LOGINJWT.DAO.Interfaces;
using STORESERVICES.API.LOGINJWT.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.DAO.Dao
{
    public class GenerateJwtDao : IGenerateJwtDao
    {
        private readonly IConfiguration _configuration;

        public GenerateJwtDao(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public JwtHeader NewHeader()
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            return _Header;
        }

        public Claim[] NewClaims(UsuarioInfo usuarioInfo)
        {
            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.Nombre),
                new Claim("apellidos", usuarioInfo.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            return _Claims;
        }

        public JwtPayload NewPAYLOAD(Claim[] claims)
        {
            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            return _Payload;
        }

        public string NewToken(JwtHeader header, JwtPayload payload)
        {
            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    header,
                    payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
