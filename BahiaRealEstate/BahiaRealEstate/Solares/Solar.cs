using BahiaRealEstate.Services;
using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class Solar:Inmueble
    {
        public Solar()
        {
            SolarFoto = new HashSet<SolarFoto>();
        }

        public decimal? PrecioMetro { get; set; }
        public int? TipoInmuebleid { get; set; }

        public virtual TipoInmueble TipoInmueble { get; set; }
        public virtual SolarDireccion SolarDireccion { get; set; }
        public virtual SolarPrecio SolarPrecio { get; set; }
        public virtual ICollection<SolarFoto> SolarFoto { get; set; }
    }
}
