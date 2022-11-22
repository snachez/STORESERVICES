using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.Data
{
    public interface IContextoLibreria : IDisposable
    {
        DatabaseFacade Database { get; }

        int SaveChanges();
    }
}
