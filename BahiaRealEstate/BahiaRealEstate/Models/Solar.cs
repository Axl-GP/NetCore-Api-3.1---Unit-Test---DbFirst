using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class Solar
    {
        public Solar()
        {
            SolarFoto = new HashSet<SolarFoto>();
        }

        public int Id { get; set; }
        public decimal? PrecioMetro { get; set; }
        public decimal Area { get; set; }
        public bool? Destacado { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int? TipoInmuebleid { get; set; }

        public virtual TipoInmueble TipoInmueble { get; set; }
        public virtual SolarDireccion SolarDireccion { get; set; }
        public virtual SolarPrecio SolarPrecio { get; set; }
        public virtual ICollection<SolarFoto> SolarFoto { get; set; }
    }
}
