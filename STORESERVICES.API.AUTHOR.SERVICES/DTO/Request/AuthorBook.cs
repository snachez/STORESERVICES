using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.SERVICES.DTO.Request
{
    public class AuthorBook : IRequest
    {
        private string _AutorLibroGuid;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid
        {
            get
            {
                this._AutorLibroGuid = Convert.ToString(Guid.NewGuid());

                return this._AutorLibroGuid;
            }
            set
            {
                this._AutorLibroGuid = value;
            }
        }
    }
}
