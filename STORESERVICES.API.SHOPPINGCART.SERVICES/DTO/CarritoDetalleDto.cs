﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES.DTO
{
    public class CarritoDetalleDto
    {
        public Guid? LibroId { get; set; }

        public string TituloLibro { get; set; }

        public string AutorLibro { get; set; }

        public DateTime? FechaPublicacion { get; set; }
    }
}
