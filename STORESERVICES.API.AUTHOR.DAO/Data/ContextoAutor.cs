using Microsoft.EntityFrameworkCore;
using STORESERVICES.API.AUTHOR.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.DAO.Data
{
    public class ContextoAutor : DbContext, IContextoAutor
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
