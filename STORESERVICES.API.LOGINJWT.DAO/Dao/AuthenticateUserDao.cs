using STORESERVICES.API.LOGINJWT.DAO.Interfaces;
using STORESERVICES.API.LOGINJWT.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.DAO.Dao
{
    public class AuthenticateUserDao : IAuthenticateUserDao
    {
        public AuthenticateUserDao()
        {
        }

        public UsuarioInfo Login<T>(T usuarioLogin)
        {
            // AQUÍ LA LÓGICA DE AUTENTICACIÓN //

            // Supondremos que el Usuario existe en la Base de Datos.
            // Retornamos un objeto del tipo UsuarioInfo, con toda
            // la información del usuario necesaria para el Token.

            UsuarioInfo result = new UsuarioInfo()
            {
                // Id del Usuario en el Sistema de Información (BD)
                Id = new Guid("B5D233F0-6EC2-4950-8CD7-F44D16EC878F"),
                Nombre = "Nombre Usuario",
                Apellidos = "Apellidos Usuario",
                Email = "email.usuario@dominio.com",
                Rol = "Administrador"
            };

            // Supondremos que el Usuario NO existe en la Base de Datos.
            // Retornamos NULL.
            //return null;

            return result;
        }
    }
}
