using Microsoft.EntityFrameworkCore;
using STORESERVICES.API.SHOPPINGCART.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.DAO.Data
{
    public class CarritoContexto : DbContext, ICarritoContexto
    {
        public CarritoContexto(DbContextOptions<CarritoContexto> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<CarritoSesion> CarritoSesion { get; set; }

        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }

    }
}
