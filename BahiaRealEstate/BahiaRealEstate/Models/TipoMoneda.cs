using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class TipoMoneda
    {
        public TipoMoneda()
        {
            PropiedadPrecio = new HashSet<PropiedadPrecio>();
            SolarPrecio = new HashSet<SolarPrecio>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<PropiedadPrecio> PropiedadPrecio { get; set; }
        public virtual ICollection<SolarPrecio> SolarPrecio { get; set; }
    }
}
