using STORESERVICES.API.BOOK.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.Interfaces
{
    public interface IBookDao
    {
        public Task<long> NewBook(string Titulo, DateTime? FechaPublicacion, Guid? AutorLibro);
        public Task<List<LibreriaMaterial>> QueryBook();
        public Task<LibreriaMaterial> QueryByIdBook(Guid? id);
    }
}
