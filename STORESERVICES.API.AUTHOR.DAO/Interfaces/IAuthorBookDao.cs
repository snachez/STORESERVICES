using STORESERVICES.API.AUTHOR.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.DAO.Interfaces
{
    public interface IAuthorBookDao
    {
        public Task<long> NewAuthorBook(string Nombre, string Apellido, DateTime? FechaNacimiento, string AutorLibroGuid);
        public List<AutorLibro> QueryAuthorBook();
        public AutorLibro QueryByIdAuthorBook(string id);
    }
}
