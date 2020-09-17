using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class Propiedad
    {
        public Propiedad()
        {
            PropiedadFoto = new List<PropiedadFoto>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Area { get; set; }
        public int? Ducha { get; set; }
        public int? Cuartos { get; set; }
        public bool? CuartoServicio { get; set; }
        public bool? AreaGym { get; set; }
        public bool? AreaLavado { get; set; }
        public bool? Caliente { get; set; }
        public bool? Destacado { get; set; }
        public int? TipoInmuebleId { get; set; }

        public virtual TipoInmueble TipoInmueble { get; set; }
        public virtual PropiedadDireccion PropiedadDireccion { get; set; }
        public virtual PropiedadPrecio PropiedadPrecio { get; set; }
        public virtual List<PropiedadFoto> PropiedadFoto { get; set; }
    }
}
