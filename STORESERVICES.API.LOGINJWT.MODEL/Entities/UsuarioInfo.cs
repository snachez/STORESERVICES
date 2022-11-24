using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.LOGINJWT.MODEL.Entities
{
    public class UsuarioInfo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
