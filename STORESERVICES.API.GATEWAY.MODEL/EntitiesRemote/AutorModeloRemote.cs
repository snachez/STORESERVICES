using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.GATEWAY.MODEL.EntitiesRemote
{
    public class AutorModeloRemote
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; }
    }
}
