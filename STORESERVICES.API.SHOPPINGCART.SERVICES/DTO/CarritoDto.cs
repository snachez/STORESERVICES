﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.SERVICES.DTO
{
    public class CarritoDto
    {
        public int CarritoId { get; set; }

        public DateTime? FechaCreacionSesion { get; set; }

        public List<CarritoDetalleDto> ListaProductos { get; set; }
    }
}
