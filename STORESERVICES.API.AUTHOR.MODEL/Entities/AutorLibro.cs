﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.MODEL.Entities
{
    public class AutorLibro
    {
        public int AutorLibroId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public ICollection<GradoAcademico>? ListaGradoAcademico { get; set; }

        public string AutorLibroGuid { get; set; }

    }
}
