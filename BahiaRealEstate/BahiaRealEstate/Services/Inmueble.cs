using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BahiaRealEstate.Services
{
    public abstract class Inmueble
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Area { get; set; }
        public bool? Destacado { get; set; }
        public int TipoInmuebleId { get; set; }
    }
}
