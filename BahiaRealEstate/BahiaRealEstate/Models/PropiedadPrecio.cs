using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class PropiedadPrecio
    {
        public int Id { get; set; }
        public int Monedaid { get; set; }
        public int Precio { get; set; }
        public string NotaPrecio { get; set; }

        public virtual Propiedad IdNavigation { get; set; }
        public virtual TipoMoneda Moneda { get; set; }
    }
}
