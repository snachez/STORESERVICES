using STORESERVICES.API.SHOPPINGCART.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.DAO.Interfaces
{
    public interface ICartSessionDao
    {
        public Task<int> NewCartSession(DateTime DateCreationSession);
        public Task<CarritoSesion> GetByIdCartSession(int CartSessionId);
    }
}
