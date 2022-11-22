using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.DAO.Data
{
    public interface IContextoAutor : IDisposable
    {
        DatabaseFacade Database { get; }

        int SaveChanges();
    }
}
