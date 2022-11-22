using Microsoft.EntityFrameworkCore;
using STORESERVICES.API.BOOK.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.Data
{
    public class ContextoLibreria : DbContext, IContextoLibreria
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }

    }
}
