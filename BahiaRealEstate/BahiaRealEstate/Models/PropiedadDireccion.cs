using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class PropiedadDireccion
    {
        public int Id { get; set; }
        public int? IdPropiedad { get; set; }
        public string Direccion { get; set; }

        public virtual Propiedad IdNavigation { get; set; }
    }
}
