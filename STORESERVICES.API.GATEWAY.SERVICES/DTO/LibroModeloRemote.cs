using STORESERVICES.API.GATEWAY.MODEL.EntitiesRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.GATEWAY.SERVICES.DTO
{
    public class LibroModeloRemote
    {
        public Guid? LibreriaMaterialId { get; set; }

        public string Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }

        public AutorModeloRemote AutorData { get; set; }

    }
}
