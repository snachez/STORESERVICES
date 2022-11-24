using STORESERVICES.API.LOGINJWT.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.DAO.Interfaces
{
    public interface IAuthenticateUserDao
    {
        public UsuarioInfo Login<T>(T usuarioLogin);
    }
}
