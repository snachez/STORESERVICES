using STORESERVICES.API.GATEWAY.MODEL.EntitiesRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.GATEWAY.DAO.Interfaces
{
    public interface IAutorRemoteDao
    {
        Task<(bool resultado, AutorModeloRemote autor, string ErrorMessage)> GetAuthor(Guid AutorId);
    }
}
