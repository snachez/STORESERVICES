using STORESERVICES.API.SHOPPINGCART.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.DAO.Interfaces
{
    public interface ICartSessionDetailDao
    {
        public Task<int> NewCartSessionDetail(DateTime CreationDate, string ProductList, int CartSessionId);
        public Task<List<string>> GetByIdCartSessionDetail(int CartSessionId);
    }
}
